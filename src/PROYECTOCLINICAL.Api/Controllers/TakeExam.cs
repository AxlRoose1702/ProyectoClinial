using MediatR;
using Microsoft.AspNetCore.Mvc;
using PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.GetAllQuery;

namespace PROYECTOCLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeExam : ControllerBase
    {
        private readonly IMediator _mediator;

        public TakeExam(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListTakeExams")]
        public async Task<IActionResult> ListTakeExams([FromQuery] GetAllTakeExamQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
