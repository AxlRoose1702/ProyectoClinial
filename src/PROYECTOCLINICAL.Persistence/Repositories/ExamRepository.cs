using Dapper;
using PROYECTOCLINICAL.Application.Dtos.Exam.Response;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Domain.Entities;
using PROYECTOCLINICAL.Persistence.Context;
using System.Data;

namespace PROYECTOCLINICAL.Persistence.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var exam = await connection.QueryAsync<GetAllExamResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return exam;
        }
    }
}
