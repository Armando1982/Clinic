namespace Clinic.Application.Dtos.Exam.Response
{
    public class GetAllExamResponseDto
    {
        public int? ExamId { get; set; }
        public string? NameExam { get; set; }
        public string? NameAnalysis { get; set; }
        public DateTime? AuditToCreateDate { get; set; }
        public DateTime? AuditToUpdateDate { get; set; }
        public string? StateExam { get; set; }
    }
}
