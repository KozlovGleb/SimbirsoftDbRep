using AutoMapper;
using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Models.Requests.Doctor;
using SimbirsoftDbRep.Models.Responses.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Controllers.Mapping
{
    public class DoctorProfile:Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="DoctorProfile"/>.
        /// </summary>
        public DoctorProfile()
        {
            CreateMap<CreateDoctorRequest, DoctorDTO>();
            CreateMap<UpdateDoctorRequest, DoctorDTO>();
            CreateMap<DoctorDTO, DoctorResponce>();
        }
    }
}
