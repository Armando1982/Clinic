using Clinic.Application.Dtos.Exam.Response;
using Clinic.Application.Interface.Interfaces;
using Clinic.Domain.Entities;
using Clinic.Pesistence.Context;
using Dapper;
using System.Data;

namespace Clinic.Pesistence.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly ApplicationDBContext _context;

        public ExamRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure)
        {
            using var connection = _context.CreateConnection;

            var exams = await connection.QueryAsync<GetAllExamResponseDto>(storedProcedure, commandType:CommandType.StoredProcedure);
            return exams;
        }
    }
}
