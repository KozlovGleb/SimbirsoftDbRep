using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimbirsoftDbRep.Common.Swagger;
using SimbirsoftDbRep.Database.Context;
using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Models.Requests;
using SimbirsoftDbRep.Models.Responses.Patient;
using SimbirsoftDbRep.Services;
using SimbirsoftDbRep.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о пациентах.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Patients)]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        UnitOfWork unitOfWork;

        /// <summary>
        /// Инициализирует экземпляр <see cref="PatientsController"/>
        /// </summary>
        /// <param name="patientService">Сервис.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public PatientsController(IPatientService patientService, ILogger<PatientsController> logger, IMapper mapper,HospitalContext context)
        {
            _patientService = patientService;
            _logger = logger;
            _mapper = mapper;
            unitOfWork = new UnitOfWork(context,mapper);
        }

        /// <summary>
        /// Получение перечня пациентов.
        /// </summary>
        /// <returns>Коллекция сущностей "Пациент".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PatientResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/Get was requested.");
            //var response = await _patientService.GetAsync(cancellationToken);
            var response = await unitOfWork.Patients.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<PatientResponse>>(response));
        }

        /// <summary>
        /// Получение пациента по Id.
        /// </summary>
        /// <returns>Cущность "Пациент".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/GetById was requested.");
            //var response = await _patientService.GetAsync(id, cancellationToken);
            var response = await unitOfWork.Patients.GetAsync(id);
            return Ok(_mapper.Map<PatientResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Пациент".
        /// </summary>
        /// <returns>Cущность "Пациент".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientResponse))]
        public async Task<IActionResult> PostAsync(CreatePatientRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/Post was requested.");
            // var response = await _patientService.CreateAsync(_mapper.Map<PatientDTO>(request));
            using (unitOfWork)
            {
               var response = await unitOfWork.Patients.CreateAsync(_mapper.Map<PatientDTO>(request));
                unitOfWork.Save();
                return Ok(_mapper.Map<PatientResponse>(response));
                //var response = await unitOfWork.Patients.CreateAsync(_mapper.Map<PatientDTO>(request));
                //unitOfWork.Save();
                //return Ok(_mapper.Map<PatientResponse>(response));      
            }
             
            
        }

        /// <summary>
        /// Изменение сущности "Пациент".
        /// </summary>
        /// <returns>Cущность "Пациент".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientResponse))]
        public async Task<IActionResult> PutAsync(UpdatePatientRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/Put was requested.");
            //var response = await _patientService.UpdateAsync(_mapper.Map<PatientDTO>(request));
            var response = await unitOfWork.Patients.UpdateAsync(_mapper.Map<PatientDTO>(request));
            return Ok(_mapper.Map<PatientResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Пациент".
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Patients/Delete was requested.");
            //await _patientService.DeleteAsync(ids);
            await unitOfWork.Patients.DeleteAsync(ids);
            return NoContent();
        }
    }
}
