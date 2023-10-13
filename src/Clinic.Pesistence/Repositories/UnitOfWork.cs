using Clinic.Application.Interface.Interfaces;
using Clinic.Domain.Entities;
using Clinic.Pesistence.Context;

namespace Clinic.Pesistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IGenericRepository<Analysis> Analysis { get;}
        public IExamRepository Exam { get; }

        public UnitOfWork( ApplicationDBContext context,IGenericRepository<Analysis> analysis)
        {
            _context = context;
            Analysis = analysis;
            Exam = new ExamRepository(_context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
