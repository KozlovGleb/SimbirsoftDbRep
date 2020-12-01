using AutoMapper;
using SimbirsoftDbRep.Database.Domain;
using SimbirsoftDbRep.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Repositories.Mapping
{
    /// <summary>
    /// Профиль маппинга (пациент).
    /// </summary>
    public class PatientProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="PatientProfile"/>
        /// </summary>
        public PatientProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
        }
    }
}
