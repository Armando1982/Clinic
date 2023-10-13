namespace Clinic.Application.Dtos.Exam.Response
{
    public class GetExamByIdResponseDto
    {
        public int  ExamId { get; set; }
        public string? NameExam { get; set; }
        public int? AnalysisId { get; set; }
    }
}
