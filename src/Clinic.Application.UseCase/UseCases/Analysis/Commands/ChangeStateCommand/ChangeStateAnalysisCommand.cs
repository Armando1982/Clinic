using Clinic.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinic.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisCommand:IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
        public int StateAnalysis { get; set; }
    }
}
