﻿using Dapper;
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
        public async Task EditTakeExam(TakeExam takeExam)
        {
            var connection = _context.CreateConnection;
            var sql = @"UPDATE takeExam SET PatientId = @PatientId, MedicId = @MedicId WHERE TakeExamId = @TakeExamId";

            var parameters = new DynamicParameters();
            parameters.Add("PatientId", takeExam.PatientId);
            parameters.Add("MedicId", takeExam.MedicId);
            parameters.Add("TakeExamId", takeExam.TakeExamId);

            await connection.ExecuteAsync(sql, param: parameters);
        }

        public async Task EditTakeExamdetail(TakeExamDetail takeExamDetail)
        {
            var connection = _context.CreateConnection;
            var sql = @"UPDATE takeExamDetail SET ExamId = @ExamId, AnalysisId = @AnalysisId WHERE TakeExamDetailId = @TakeExamDetailId";

            var parameters = new DynamicParameters();
            parameters.Add("ExamId", takeExamDetail.ExamId);
            parameters.Add("AnalysisId", takeExamDetail.AnalysisId);
            parameters.Add("TakeExamDetailId", takeExamDetail.TakeExamDetailId);

            await connection.ExecuteAsync(sql, param: parameters);

        }

        public async Task<bool> ChangeStateTakeExam(TakeExam takeExam)
        { 
            var connection = _context.CreateConnection;
            var sql = @"UPDATE takeExam SET State = @State WHERE TakeExamId = @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("State", takeExam.State);
            parameters.Add("TakeExamId", takeExam.TakeExamId);

            var recordsAffected = await connection.ExecuteAsync(sql, param: parameters);
            return recordsAffected > 0;

        }
    }
}
