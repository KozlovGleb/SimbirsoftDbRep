using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimbirsoftDbRep.Database.Context;
using SimbirsoftDbRep.Database.Domain;
using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Models.Requests.Doctor;
using SimbirsoftDbRep.Models.Responses.Doctor;
using SimbirsoftDbRep.UoW;

namespace SimbirsoftDbRep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;
        private readonly IMapper _mapper;
        UnitOfWork unitOfWork;

        /// <summary>
        /// Инициализирует экземпляр <see cref="PatientsController"/>
        /// </summary>
        /// <param name="patientService">Сервис.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public DoctorsController( ILogger<PatientsController> logger, IMapper mapper, HospitalContext context)
        {
            _logger = logger;
            _mapper = mapper;
            unitOfWork = new UnitOfWork(context, mapper);
        }

        /// <summary>
        /// Получение перечня пациентов.
        /// </summary>
        /// <returns>Коллекция сущностей "Пациент".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DoctorResponce>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/Get was requested.");
            var response = await unitOfWork.Doctors.GetAsync(cancellationToken);
            unitOfWork.Save();
            return Ok(_mapper.Map<IEnumerable<DoctorResponce>>(response));
        }

        /// <summary>
        /// Получение пациента по Id.
        /// </summary>
        /// <returns>Cущность "Пациент".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DoctorResponce))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/GetById was requested.");
            var response = await unitOfWork.Doctors.GetAsync(id);
            unitOfWork.Save();
            return Ok(_mapper.Map<DoctorResponce>(response));
        }

        /// <summary>
        /// Добавление сущности "Пациент".
        /// </summary>
        /// <returns>Cущность "Пациент".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DoctorResponce))]
        public async Task<IActionResult> PostAsync(CreateDoctorRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/Post was requested.");
            var response = await unitOfWork.Doctors.CreateAsync(_mapper.Map<DoctorDTO>(request));
            unitOfWork.Save();
            return Ok(_mapper.Map<DoctorResponce>(response));
        }

        /// <summary>
        /// Изменение сущности "Пациент".
        /// </summary>
        /// <returns>Cущность "Пациент".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DoctorResponce))]
        public async Task<IActionResult> PutAsync(UpdateDoctorRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/Put was requested.");
            var response = await unitOfWork.Doctors.UpdateAsync(_mapper.Map<DoctorDTO>(request));
            unitOfWork.Save();
            return Ok(_mapper.Map<DoctorResponce>(response));
        }

        /// <summary>
        /// Удаление сущностей "Пациент".
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Patients/Delete was requested.");
            await unitOfWork.Doctors.DeleteAsync(ids);
            unitOfWork.Save();
            return NoContent();
        }
    }
}
