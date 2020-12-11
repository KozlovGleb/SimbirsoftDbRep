using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Models.Requests
{
    /// <summary>
    /// Запрос на изменение пациента.
    /// </summary>
    public class UpdatePatientRequest:CreatePatientRequest
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        [Required]
        public long Id { get; set; }
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
