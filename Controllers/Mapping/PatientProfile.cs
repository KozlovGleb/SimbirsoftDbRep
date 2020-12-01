using AutoMapper;
using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Models.Requests;
using SimbirsoftDbRep.Models.Responses.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Controllers.Mapping
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Пациент".
    /// </summary>
    public class PatientProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="PatientProfile"/>.
        /// </summary>
        public PatientProfile()
        {
            CreateMap<CreatePatientRequest, PatientDTO>();
            CreateMap<UpdatePatientRequest, PatientDTO>();
            CreateMap<PatientDTO, PatientResponse>();
        }
    }
}
