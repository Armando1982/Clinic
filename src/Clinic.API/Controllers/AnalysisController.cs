using Clinic.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using Clinic.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using Clinic.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;
using Clinic.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using Clinic.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;
using Clinic.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListAnalysis()
        {
            var response = await _mediator.Send(new GetAllAnalisysQuery());
            return Ok(response);
        }

        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> AnalysisById(int analysisId)
        {
            var response = await _mediator.Send(new GetByAnalysisByIdQuery() { AnalysisId = analysisId});
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditAnalysis([FromBody] EditAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> DeleteAnalysis(int analysisId)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId});
            return Ok(response);
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeState([FromBody] ChangeStateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
