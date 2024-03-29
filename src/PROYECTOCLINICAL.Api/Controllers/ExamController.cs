﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Commands.ChangeStateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Commands.CreateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Commands.DeleteCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Commands.UpdateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Queries.GetAllQuery;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Queries.GetByIdQuery;

namespace PROYECTOCLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListExams")]
        public async Task<IActionResult> ListExams([FromQuery] GetAllExamQuery query) 
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{examId:int}")]
        public async Task<IActionResult> ExamById(int examId)
        {
            var response = await _mediator.Send(new GetExamByIdQuery() { ExamId = examId });
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterExam([FromBody] CreateExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditExam([FromBody] UpdateExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("Remove/{examId:int}")]
        public async Task<IActionResult> RemoveExam(int examId)
        {
            var response = await _mediator.Send(new DeleteExamCommand() { ExamId = examId});
            return Ok(response);
        }
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateExam([FromBody] ChangeStateExamCommand command)
        {
            var response = await _mediator.Send(command); 
            return Ok(response);
        }
    }
}
