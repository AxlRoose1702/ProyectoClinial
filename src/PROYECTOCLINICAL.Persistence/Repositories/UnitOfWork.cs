using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Analysis> Analysis { get; }

        public UnitOfWork(IGenericRepository<Analysis> analysis)
        {
            Analysis = analysis;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
