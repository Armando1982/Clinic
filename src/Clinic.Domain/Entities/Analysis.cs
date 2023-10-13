namespace Clinic.Domain.Entities
{
    public class Analysis
    {
        public int? AnalysisId { get; set; }
        public string? NameAnalysis { get; set; }
        public int? StateAnalysis { get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}
