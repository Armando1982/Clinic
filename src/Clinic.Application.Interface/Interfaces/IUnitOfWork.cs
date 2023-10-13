using Clinic.Domain.Entities;

namespace Clinic.Application.Interface.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Analysis> Analysis { get; }
        IExamRepository Exam { get; }
    }

}
