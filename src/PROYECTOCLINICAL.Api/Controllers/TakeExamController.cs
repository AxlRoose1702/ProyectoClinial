using MediatR;
using Microsoft.AspNetCore.Mvc;
using PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.Command.CreateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.GetAllQuery;
using PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.GetByIdQuery;

namespace PROYECTOCLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TakeExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListTakeExams")]
        public async Task<IActionResult> ListTakeExams([FromQuery] GetAllTakeExamQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{takeExamId:int}")]
        public async Task<IActionResult> takeExamById(int takeExamId)
        {
            var response = await _mediator.Send(new GetTakeExamByIdQuery() { TakeExamId = takeExamId});
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterTakeExam([FromQuery] CreateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
