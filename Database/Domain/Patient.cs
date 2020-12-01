using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Database.Domain
{
    public class Patient : BaseEntity
    {
        /// <summary>
        /// Артикул.
        /// </summary>
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [StringLength(2500)]
        public string PhoneNumber { get; set; }

    }
}
