using SimbirsoftDbRep.Database.Domain;
using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Repositories.Interfaces.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями "Карта пациента".
    /// </summary>
    public interface IPatientCardRepository: ICrudRepository<PatientCardDto, PatientCard>
    {
    }
}
