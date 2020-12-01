using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Services.CRUD
{
    /// <summary>
    /// Интерфейс сервиса для получения сущностей.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TModel">Domain model.</typeparam>
    public interface IGettable<TDto>
    {
        /// <summary>
        /// Получение сущностей.
        /// </summary>
        /// <param name="token">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущности.</returns>
        Task<IEnumerable<TDto>> GetAsync(CancellationToken token = default);
    }
}
