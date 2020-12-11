using SimbirsoftDbRep.Database.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Models.DTO
{
    public class PatientCardDto:BaseDto
    {
        /// <summary>
        /// Название болезни.
        /// </summary>
        [StringLength(250)]
        [Required]
        public string DiseaseName { get; set; }

        /// <summary>
        /// Дата визита.
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
