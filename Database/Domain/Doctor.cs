using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Database.Domain
{
    public class Doctor:BaseEntity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        [StringLength(25)]
        [Required]
        public string Phone { get; set; }
    }
}
