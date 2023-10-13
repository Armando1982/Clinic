namespace Clinic.Domain.Entities
{
    public class Exam
    {
        public int? ExamId { get; set; }
        public string? NameExam { get; set; }
        public int? AnalysisId { get; set; }
        public int? StateExam { get; set; }
        public DateTime? AuditToCreateDate { get; set; }
        public DateTime? AuditToUpdateDate { get; set; }
    }
}
