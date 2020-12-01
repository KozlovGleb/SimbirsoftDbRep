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
        /// Имя.
        /// </summary>
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Телефонный номер.
        /// </summary>
        [StringLength(2500)]
        public string PhoneNumber { get; set; }

    }
}
