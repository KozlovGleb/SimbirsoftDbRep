using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Models.Responses.Patient
{
    /// <summary>
    /// Ответ на запросы для пациента.
    /// </summary>
    public class PatientResponse
    {
         /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя пациента.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Телефонный номер пациента.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
