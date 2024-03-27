using PROYECTOCLINICAL.Application.Interface.Interfaces;
using PROYECTOCLINICAL.Domain.Entities;
using System.Transactions;

namespace PROYECTOCLINICAL.Application.Interface.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analysis> Analysis { get; }
        IExamRepository Exam { get; }
        IPatientRepository Patient { get; }
        IMedicRepository Medic { get; }
        ITakeExamRepository TakeExam { get; }
        TransactionScope BeginTransaction();
    }
}
