using Clinic.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinic.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
    }
}
