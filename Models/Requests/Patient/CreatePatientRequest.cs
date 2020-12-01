using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Models.Requests
{

    /// <summary>
    /// Запрос на создание нового пациента.
    /// </summary>
    public class CreatePatientRequest
    {
        /// <summary>
        /// Имя пациента.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Номер телефона пациента.
        /// </summary>
        [MaxLength(2000)]
        public string PhoneNumber { get; set; }
    }
}
