using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Database.Domain
{
    public class PatientCard:BaseEntity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        [StringLength(250)]
        [Required]
        public string DiseaseName { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        [StringLength(25)]
        [Required]
        public string DateOfVisit { get; set; }
        public Doctor Doctor { get; set; }
        public long DoctorId { get; set; }
        public Patient Patient { get; set; }
        public long PatientId { get; set; }
    }
}
