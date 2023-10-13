using Clinic.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using Clinic.Application.UseCase.UseCases.Exam.Commands.EditCommand;
using Clinic.Application.UseCase.UseCases.Exam.Queries.GetAllQuery;
using Clinic.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
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
        public async Task<IActionResult> ListExams()
        {
            var response = await _mediator.Send(new GetAllExamQuery());
            return Ok(response);
        }

        [HttpGet("{examId:int}")]
        public async Task<IActionResult> ExamById(int examId)
        {
            var response = await _mediator.Send(new GetExamByIdQuery() { ExamId = examId });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterExam([FromBody] CreateExamCommand command )
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditExam([FromBody] EditExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
