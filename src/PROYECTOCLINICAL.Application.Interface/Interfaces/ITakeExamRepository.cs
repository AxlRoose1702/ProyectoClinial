using PROYECTOCLINICAL.Application.Dtos.TakeExam.Response;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.Interface.Interfaces
{
    public interface ITakeExamRepository : IGenericRepository<TakeExam>
    {
        Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExams(string storeProcedure, object parameter);
        Task<TakeExam> GetTakeExamById(int takeExamId);
        Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId);
        Task<TakeExam> RegisterTakeExam(TakeExam takeExam);
        Task RegisterTakeExamDetail(TakeExamDetail takeExamDetail);
    }
}
