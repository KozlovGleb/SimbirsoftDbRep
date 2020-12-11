using AutoMapper;
using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Models.Requests.PatientCard;
using SimbirsoftDbRep.Models.Responses.PatientCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Controllers.Mapping
{
    public class PatientCardProfile:Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="PatientProfile"/>.
        /// </summary>
        public PatientCardProfile()
        {
            CreateMap<CreatePatientCardRequest, PatientCardDto>();
            CreateMap<UpdatePatientCardRequest, PatientCardDto>();
            CreateMap<PatientCardDto, PatientCardResponse>();
        }
    }
}
