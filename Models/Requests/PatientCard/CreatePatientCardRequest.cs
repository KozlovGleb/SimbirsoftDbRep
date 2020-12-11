using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Models.Requests.PatientCard
{
    public class CreatePatientCardRequest
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

        //public Database.Domain.Doctor Doctor { get; set; }

        /// <summary>
        /// ID доктора.
        /// </summary>
        public long DoctorId { get; set; }
        //public Database.Domain.Patient Patient { get; set; }

        /// <summary>
        /// ID пациента.
        /// </summary>
        public long PatientId { get; set; }
    }
}
