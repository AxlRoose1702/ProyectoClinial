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

        public async Task<TakeExam> RegisterTakeExam(TakeExam takeExam)
        {
            var connection = _context.CreateConnection;
            var sql = @"INSERT INTO TakeExam(PatientId, MedicId, State, AuditCreateDate)
                        VALUES (@PatientId, @MedicId, @State, @AuditCreateDate)
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var parameters = new DynamicParameters();
            parameters.Add("PatientId", takeExam.PatientId);
            parameters.Add("MedicId", takeExam.MedicId);
            parameters.Add("State", 1);
            parameters.Add("AuditCreateDate", DateTime.Now);

            var takeExamId = await connection.QuerySingleOrDefaultAsync<int>(sql, param:parameters);
            takeExam.TakeExamId = takeExamId;
            return takeExam;

        }

        public async Task RegisterTakeExamDetail(TakeExamDetail takeExamDetail)
        {
            var connection = _context.CreateConnection;
            var sql = @"INSERT INTO TakeExamDetail(TakeExamId, ExamId, AnalysisId)
                        VALUES (@TakeExamId, @ExamId, @AnalysisId)";

            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamDetail.TakeExamId);
            parameters.Add("ExamId", takeExamDetail.ExamId);
            parameters.Add("AnalysisId", takeExamDetail.AnalysisId);

            await connection.ExecuteAsync(sql, param:parameters);

        }
    }
}
