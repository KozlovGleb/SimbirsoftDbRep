using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Services.CRUD
{
    /// <summary>
    /// Интерфейс сервиса для получения сущности по идентификатору.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TModel">Domain model.</typeparam>
    public interface IGettableById<TDto>
    {
        /// <summary>
        /// Получение сущности по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Экземпляр сущности.</returns>
        Task<TDto> GetAsync(long id, CancellationToken token = default);
    }
}
