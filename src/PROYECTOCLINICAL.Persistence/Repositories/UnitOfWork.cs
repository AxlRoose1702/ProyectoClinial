using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Domain.Entities;
using PROYECTOCLINICAL.Persistence.Context;

namespace PROYECTOCLINICAL.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Analysis> Analysis { get; }

        public IExamRepository Exam { get; }

        public UnitOfWork(IGenericRepository<Analysis> analysis, ApplicationDbContext context)
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
