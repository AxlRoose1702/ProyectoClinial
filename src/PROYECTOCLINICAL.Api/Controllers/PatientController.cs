using MediatR;
using Microsoft.AspNetCore.Mvc;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.Command.ChangeStateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.Command.CreateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.Command.DeleteCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.Command.UpdateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.GetAllQuery;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.GetByIdQuery;

namespace PROYECTOCLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListPatient")]
        public async Task<IActionResult> ListPatient()
        {
            var response = await _mediator.Send( new GetAllPatientQuery() );
            return Ok(response);
        }

        [HttpGet("{patientId:int}")]
        public async Task<IActionResult> PatientById(int patientId)
        {
            var response = await _mediator.Send(new GetPatientByIdQuery() { PatientId = patientId });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterPatient([FromBody] CreatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> PatientEdit([FromBody] UpdatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("Remove/{patientId:int}")]
        public async Task<IActionResult> PatientRemove(int patientId)
        {
            var response = await _mediator.Send(new DeletePatientCommand() { PatientId = patientId});
            return Ok(response);
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeState([FromBody] ChangeStatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
