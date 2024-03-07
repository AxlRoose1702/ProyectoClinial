using Dapper;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCLINICAL.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            return await connection.QueryAsync<T>(storedProcedure, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objParams = new DynamicParameters(parameter);
            return await connection
                .QuerySingleOrDefaultAsync<T>(storedProcedure, param: objParams, commandType: System.Data.CommandType.StoredProcedure);
        }
        public async Task<bool> ExecAsync(string storedProcedure, object parameters)
        {
            using var connection = _context.CreateConnection;
            var objParams = new DynamicParameters(parameters);
            var recordsAffected = await connection.ExecuteAsync(storedProcedure, param: objParams, commandType: System.Data.CommandType.StoredProcedure);
            return recordsAffected > 0;
        }
    }
}
