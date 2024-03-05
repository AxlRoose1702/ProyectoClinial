﻿using Dapper;
using PROYECTOCLINICAL.Application.Interface;
using PROYECTOCLINICAL.Domain.Entities;
using PROYECTOCLINICAL.Persistence.Context;

namespace PROYECTOCLINICAL.Persistence.Repositories
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ApplicationDbContext _context;

        public AnalysisRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Analysis>> ListAnalysis()
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisList";

            var analysis = await connection.QueryAsync<Analysis>(query,commandType: System.Data.CommandType.StoredProcedure);
            return analysis;
        }

        public async Task<Analysis> AnalysisById(int analysisId)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisById";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);

            var analysis = await connection.QuerySingleOrDefaultAsync<Analysis>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

            return analysis;
        }

        public async Task<bool> AnalysisRegister(Analysis analysis)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisRegister";

            var parameters = new DynamicParameters();
            parameters.Add("Name", analysis.Name);
            parameters.Add("State", 1);
            parameters.Add("AuditCreateDate", DateTime.Now);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

            return recordsAffected > 0;
        }

        public async Task<bool> AnalysisEdit(Analysis analysis)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisEdit";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysis.AnalysisId);
            parameters.Add("Name", analysis.Name);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

            return recordsAffected > 0;
        }
    }
}