using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Services.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными о пациенте.
    /// </summary>
    public interface IPatientService:ICrudService<PatientDTO>
    {
    }
}
