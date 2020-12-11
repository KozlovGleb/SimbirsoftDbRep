using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Models.Responses.Doctor
{
    public class DoctorResponce
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя доктора.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Телефонный номер доктора.
        /// </summary>
        public string Phone { get; set; }
    }
}
