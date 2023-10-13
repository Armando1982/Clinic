using Clinic.Application.Dtos.Exam.Response;
using Clinic.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinic.Application.UseCase.UseCases.Exam.Queries.GetAllQuery
{
    public class GetAllExamQuery : IRequest<BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {

    }
}
