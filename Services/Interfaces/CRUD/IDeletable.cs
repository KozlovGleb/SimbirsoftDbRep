using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Services.CRUD
{
    /// <summary>
    /// Интерфейс сервиса для удаления сущностей.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TModel">Domain model.</typeparam>
    public interface IDeletable
    {
        /// <summary>
        /// Групповое удаление сущностей.
        /// </summary>
        /// <param name="ids">Идентификаторы.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        Task DeleteAsync(params long[] ids);
    }
}
