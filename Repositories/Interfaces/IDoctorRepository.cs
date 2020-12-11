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
    /// Интерфейс репозитория для работы с сущностями "Доктор"
    /// </summary>
    public interface IDoctorRepository: ICrudRepository<DoctorDTO, Doctor>
    {
    }
}
