using Clinic.Domain.Entities;

namespace Clinic.Application.Interface.Interfaces
{
    public interface IAnalysisRepository
    {
        Task<IEnumerable<Analysis>> ListAnalysis();
        Task<Analysis> AnalysisById(int analysisId);
        Task<bool> AnalysisRegister(Analysis analysis);
        Task<bool> AnalysisEdit(Analysis analysis);
        Task<bool> AnalysisDelete(int analysisId);
    }
}
