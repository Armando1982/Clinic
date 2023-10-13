using Clinic.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinic.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public string? NameAnalysis { get; set; }
    }
}
