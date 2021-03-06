﻿using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Repositories;
using SimbirsoftDbRep.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Services
{
    /// <summary>
    /// Сервис для работы с данными о пациенте.
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IPatientRepositoty _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="PatientService"/>.
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        public PatientService(IPatientRepositoty repository)
        {
            _repository = repository;
        }

        ///<inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<PatientDTO> CreateAsync(PatientDTO dto)
        {
            return await _repository.CreateAsync(dto);
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(params long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<PatientDTO> GetAsync(long id, CancellationToken token = default)
        {
            return await _repository.GetAsync(id);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<PatientDTO>> GetAsync(CancellationToken token = default)
        {
            return await _repository.GetAsync();
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<PatientDTO> UpdateAsync(PatientDTO dto)
        {
            return await _repository.UpdateAsync(dto);
        }
    }
}
