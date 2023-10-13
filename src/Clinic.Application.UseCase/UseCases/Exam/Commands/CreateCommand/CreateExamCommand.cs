using Clinic.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinic.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamCommand : IRequest<BaseResponse<bool>>
    {
        public string? NameExam { get; set; }
        public int AnalysisId { get; set; }
    }
}
