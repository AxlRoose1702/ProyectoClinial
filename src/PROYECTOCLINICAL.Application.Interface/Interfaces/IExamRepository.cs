using PROYECTOCLINICAL.Application.Dtos.Exam.Response;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.Interface.Interface
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure, object parameter);
    }
}