    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Database.Domain
{ 
     /// <summary>
     /// Базовый класс для слабых сущностей.
     /// </summary>
     /// <typeparam name="TEntity1">Связанная сущность - 1.</typeparam>
     /// <typeparam name="TEntity2">Связанная сущность - 2.</typeparam>
public abstract class BaseEntityWithLinks<TEntity1, TEntity2> where TEntity1 : BaseEntity
        where TEntity2 : BaseEntity
    {
        /// <summary>
        /// Идентификатор первой связанной сущности.
        /// </summary>
        public long Entity1Id { get; set; }

        /// <summary>
        /// Связанная сущность - 1.
        /// </summary>
        public TEntity1 Entity1 { get; set; }

        /// <summary>
        /// Идентификатор второй связанной сущности.
        /// </summary>
        public long Entity2Id { get; set; }

        /// <summary>
        /// Связанная сущность - 2.
        /// </summary>
        public TEntity2 Entity2 { get; set; }
    }
}

