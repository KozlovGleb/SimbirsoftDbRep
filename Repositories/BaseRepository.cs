using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimbirsoftDbRep.Database.Context;
using SimbirsoftDbRep.Database.Domain;
using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Repositories.Interfaces.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Repositories
{
    /// <summary>
    /// Базовый класс репозитория для работы с CRUD.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TModel">Доменная модель.</typeparam>
    public abstract class BaseRepository<TDto, TModel> : ICrudRepository<TDto, TModel>
        where TDto : BaseDto
        where TModel : BaseEntity
    {
        private readonly IMapper _mapper;
        protected readonly HospitalContext _сontext;
        protected DbSet<TModel> DbSet => _сontext.Set<TModel>();

        /// <summary>
        /// Инициализирует экземпляр <see cref="BaseRepository{TDto, TModel}"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        protected BaseRepository(HospitalContext context, IMapper mapper)
        {
            _сontext = context;
            _mapper = mapper;
        }

        /// <inheritdoc cref="ICreatable{TDto, TModel}.CreateAsync(TDto)"/>
        public async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TModel>(dto);
            await DbSet.AddAsync(entity);
            return await GetAsync(entity.Id);
        }

        /// <inheritdoc cref="IDeletable{TDto, TModel}.DeleteAsync(long[])"/>
        public async Task DeleteAsync(params long[] ids)
        {
            var entities = await DbSet
                                .Where(x => ids.Contains(x.Id))
                                .ToListAsync();

            _сontext.RemoveRange(entities);
 
        }

        /// <inheritdoc cref="IGettableById{TDto, TModel}.GetAsync(long)"/>
        public async Task<TDto> GetAsync(long id)
        {
            var entity = await   DefaultIncludeProperties(DbSet)
                              .AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);

            var dto = _mapper.Map<TDto>(entity);

            return dto;
        }

        /// <inheritdoc cref="IUpdatable{TDto, TModel}.UpdateAsync(TDto, CancellationToken)"/>
        public async Task<TDto> UpdateAsync(TDto dto, CancellationToken token = default)
        {
            var entity = _mapper.Map<TModel>(dto);
            _сontext.Update(entity);

            return _mapper.Map<TDto>(entity);
        }

        /// <inheritdoc cref="IGettable{TDto, TModel}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<TDto>> GetAsync(CancellationToken token = default)
        {
            var entities = await DefaultIncludeProperties(DbSet)
                              .AsNoTracking().ToListAsync();
                              

            var dtos = _mapper.Map<IEnumerable<TDto>>(entities);

            return dtos;
        }
        /// <summary>
        /// Добавляет к выборке связанные параметры.
        /// </summary>
        /// <param name="dbSet">Коллекция DbSet репозитория.</param>
        protected virtual IQueryable<TModel> DefaultIncludeProperties(DbSet<TModel> dbSet) => dbSet;
    }
}
