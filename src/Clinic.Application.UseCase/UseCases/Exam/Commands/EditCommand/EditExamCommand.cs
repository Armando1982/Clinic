using Clinic.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinic.Application.UseCase.UseCases.Exam.Commands.EditCommand
{
    public class EditExamCommand:IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
        public string? NameExam { get; set;}
        public int AnalysisId { get; set; }
    }
}
