using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Services.CRUD
{
    public interface ICrudService<TDto>:
         ICreatable<TDto>,
            IGettableById<TDto>,
            IGettable<TDto>,
            IUpdatable<TDto>,
            IDeletable
    {
    }
}
