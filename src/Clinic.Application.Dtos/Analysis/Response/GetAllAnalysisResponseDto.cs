namespace Clinic.Application.Dtos.Analysis.Response
{
    public class GetAllAnalysisResponseDto
    {
        public int AnalysisId { get; set; }
        public string? NameAnalysis { get; set; }
        public int StateAnalysis { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string? StateAnalysisStr { get; set; }
    }
}
