using AutoMapper;
using SimbirsoftDbRep.Database.Domain;
using SimbirsoftDbRep.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Repositories.Mapping
{
    public class PatientCardProfile:Profile
    {
        public PatientCardProfile()
        {
            CreateMap<PatientCard, PatientCardDto>().ReverseMap();
        }
    }
}
