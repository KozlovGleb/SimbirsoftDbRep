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
    /// Профиль маппинга (одежда).
    /// </summary>
    public class PatientProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="DressProfile"/>
        /// </summary>
        public PatientProfile()
        {
            CreateMap<Patient, PatietnDTO>().ReverseMap();
        }
    }
}
