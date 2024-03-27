using Dapper;
using PROYECTOCLINICAL.Application.Dtos.TakeExam.Response;
using PROYECTOCLINICAL.Application.Interface.Interfaces;
using PROYECTOCLINICAL.Domain.Entities;
using PROYECTOCLINICAL.Persistence.Context;
using System.Data;

namespace PROYECTOCLINICAL.Persistence.Repositories
{
    public class TakeExamRepository : GenericRepository<TakeExam>, ITakeExamRepository
    {
        private readonly ApplicationDbContext _context;

        public TakeExamRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExams(string storeProcedure, object parameter)
        {
            var conection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var takeExams = await conection.QueryAsync<GetAllTakeExamResponseDto>(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return takeExams;
        }

        public async Task<TakeExam> GetTakeExamById(int takeExamId)
        {
            var connection = _context.CreateConnection;
            var sql = @"SELECT takeExamId, PatientId, MedicId FROM TakeExam WHERE TakeExamId = @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);

            var takeExam = await connection.QuerySingleOrDefaultAsync<TakeExam>(sql, param:parameters);
            return takeExam;
        }

        public async Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId)
        {
            var connection = _context.CreateConnection;
            var sql = @"SELECT takeExamDetailId, TakeExamId, ExamId, AnalysisId FROM TakeExamDetail WHERE TakeExamId = @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);

            var takeExamDetail = await connection.QueryAsync<TakeExamDetail>(sql, param: parameters);
            return takeExamDetail!;
        }
    }
}
