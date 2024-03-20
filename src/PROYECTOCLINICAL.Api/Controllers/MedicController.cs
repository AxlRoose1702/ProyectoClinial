using MediatR;
using Microsoft.AspNetCore.Mvc;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Commands.CreateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Commands.UpdateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Queries.GetAllQuery;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Queries.GetByIdQuery;

namespace PROYECTOCLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("ListMedics")]
        public async Task<IActionResult> ListMedics()
        {
            var response = await _mediator.Send(new GetAllMedicQuery());
            return Ok(response);
        }

        [HttpGet("{medicId:int}")]
        public async Task<IActionResult> MedicById(int medicId)
        {
            var response = await _mediator.Send(new GetMedicByIdQuery() { MedicId = medicId });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterMedic([FromBody] CreateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> EditMedic([FromBody] UpdateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}