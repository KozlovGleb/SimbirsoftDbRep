using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Models.DTO
{
    public class DoctorDTO:BaseDto
    {
        /// <summary>
        /// Имя.
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
}
