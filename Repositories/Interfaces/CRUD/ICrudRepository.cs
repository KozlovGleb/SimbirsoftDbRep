using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Repositories.Interfaces.CRUD
{
    /// <summary>
 /// Интерфейс репозитория с базовыми CRUD-операциями.
 /// </summary>
 /// <typeparam name="TDto"></typeparam>
 /// <typeparam name="TModel"></typeparam>
    public interface ICrudRepository<TDto, TModel> :
        ICreatable<TDto, TModel>,
        IGettableById<TDto, TModel>,
        IGettable<TDto, TModel>,
        IUpdatable<TDto, TModel>,
        IDeletable
    {
    }
}
