using Clinic.Application.Dtos.Analysis.Response;
using Clinic.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinic.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery
{
    public class GetAllAnalisysQuery : IRequest<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {

    }
}
