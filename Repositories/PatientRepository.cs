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
    /// <summary>
    /// Репозиторий для работы с сущностями "Пациент".
    /// </summary>
    public class PatientRepository : BaseRepository<PatientDTO, Patient>, IPatientRepositoty
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="DressRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public PatientRepository(HospitalContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
