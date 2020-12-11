﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Models.Requests.Doctor
{
    public class UpdateDoctorRequest
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        [Required]
        public long Id { get; set; }
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
