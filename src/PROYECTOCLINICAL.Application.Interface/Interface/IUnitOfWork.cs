using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.Interface.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analysis> Analysis { get; }
    }
}
