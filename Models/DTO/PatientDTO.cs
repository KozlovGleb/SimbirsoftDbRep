using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="Patient"/>
    /// </summary>
    public class PatientDTO : BaseDto
    {
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
