using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Models.DTO
{
    public abstract class BaseDto
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }
    }
}
