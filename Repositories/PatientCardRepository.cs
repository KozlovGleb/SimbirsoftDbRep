using AutoMapper;
using SimbirsoftDbRep.Database.Context;
using SimbirsoftDbRep.Database.Domain;
using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Repositories
{
    public class PatientCardRepository: BaseRepository<PatientCardDto, PatientCard>, IPatientCardRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="PatientRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public PatientCardRepository(HospitalContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
