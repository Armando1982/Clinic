using Clinic.Application.Interface.Interfaces;
using Clinic.Domain.Entities;
using Clinic.Pesistence.Context;
using Dapper;
using System.Data;

namespace Clinic.Pesistence.Repositories
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ApplicationDBContext _context;

        public AnalysisRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Analysis>> ListAnalysis()
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisList";
            var analysis = await connection.QueryAsync<Analysis>(query, commandType: CommandType.StoredProcedure);
            return analysis;
        }

        public async Task<Analysis> AnalysisById(int analysisId)
        {
            using var connection = _context.CreateConnection;
            var query = "uspAnalysisById";
            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);
            var analysis = await connection.QuerySingleOrDefaultAsync<Analysis>(query,param:parameters, commandType:CommandType.StoredProcedure);

            return analysis;
        }

        public async Task<bool> AnalysisRegister(Analysis analysis)
        {
            using var connection = _context.CreateConnection;
            var query = "uspAnalysisRegister";
            var parameters = new DynamicParameters();
            parameters.Add("NameAnalysis", analysis.NameAnalysis);
            parameters.Add("StateAnalysis", 1);
            parameters.Add("AuditCreateDate", DateTime.Now);

            var recordsAffected = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }

        public async Task<bool> AnalysisEdit(Analysis analysis)
        {
            using var connection = _context.CreateConnection;
            var query = "uspAnalisysEdit";
            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysis.AnalysisId);
            parameters.Add("NameAnalysis", analysis.NameAnalysis);

            var recordsAffected = await connection.ExecuteAsync(query, param:parameters, commandType: CommandType.StoredProcedure);
            return recordsAffected > 0;

        }

        public async Task<bool> AnalysisDelete(int analysisId)
        {
            using var connection = _context.CreateConnection;
            var query = "uspAnalysisDelete";
            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);
            var recordsAffected = await connection.ExecuteAsync(query, param: parameters, commandType:CommandType.StoredProcedure);

            return recordsAffected > 0;
        }
    }
}
