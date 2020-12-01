using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Services.CRUD
{
    /// <summary>
    /// Интерфейс сервиса для изменения сущности.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TModel">Domain model.</typeparam>
  public  interface IUpdatable<TDto>
    {
        /// <summary>
        /// Изменение сущности.
        /// </summary>
        /// <param name="dto">DTO.</param>
        /// <param name="token">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Обновленная сущность.</returns>
        Task<TDto> UpdateAsync(TDto dto);
    }
}
