using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimbirsoftDbRep.Database.Context;
using SimbirsoftDbRep.Database.Domain;
using SimbirsoftDbRep.Models.DTO;
using SimbirsoftDbRep.Models.Requests.PatientCard;
using SimbirsoftDbRep.Models.Responses.PatientCard;
using SimbirsoftDbRep.UoW;

namespace SimbirsoftDbRep.Controllers
{
    /// <summary>
    /// Контроллер для сущности "Карта пациента"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
 
    public class PatientCardsController : ControllerBase
    {
        private readonly ILogger<PatientCardsController> _logger;
        private readonly IMapper _mapper;
        UnitOfWork unitOfWork;

        /// <summary>
        /// Инициализирует экземпляр <see cref="PatientsController"/>
        /// </summary>
        /// <param name="patientService">Сервис.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public PatientCardsController(ILogger<PatientCardsController> logger, IMapper mapper, HospitalContext context)
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PatientCardResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/Get was requested.");
            var response = await unitOfWork.PatientCards.GetAsync(cancellationToken);
            unitOfWork.Save();
            return Ok(_mapper.Map<IEnumerable<PatientCardResponse>>(response));
        }

        /// <summary>
        /// Получение пациента по Id.
        /// </summary>
        /// <returns>Cущность "Пациент".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientCardResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/GetById was requested.");
            //var response = await _patientService.GetAsync(id, cancellationToken);
            var response = await unitOfWork.PatientCards.GetAsync(id);
            unitOfWork.Save();
            return Ok(_mapper.Map<PatientCardResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Пациент".
        /// </summary>
        /// <returns>Cущность "Пациент".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientCardResponse))]
        public async Task<IActionResult> PostAsync(CreatePatientCardRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/Post was requested.");
            var response = await unitOfWork.PatientCards.CreateAsync(_mapper.Map<PatientCardDto>(request));
            unitOfWork.Save();
            return Ok(_mapper.Map<PatientCardResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Пациент".
        /// </summary>
        /// <returns>Cущность "Пациент".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientCardResponse))]
        public async Task<IActionResult> PutAsync(UpdatePatientCardRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Patients/Put was requested.");
            
            var response = await unitOfWork.PatientCards.UpdateAsync(_mapper.Map<PatientCardDto>(request));
            unitOfWork.Save();
            return Ok(_mapper.Map<PatientCardResponse>(response));
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
            await unitOfWork.PatientCards.DeleteAsync(ids);
            unitOfWork.Save();
            return NoContent();
        }
    }
}
