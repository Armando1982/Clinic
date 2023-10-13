using Clinic.Application.Dtos.Exam.Response;
using Clinic.Domain.Entities;

namespace Clinic.Application.Interface.Interfaces
{
    public interface IExamRepository:IGenericRepository<Exam>
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure);

    }
}
