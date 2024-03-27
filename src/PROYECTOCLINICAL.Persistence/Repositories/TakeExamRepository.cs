using Dapper;
using PROYECTOCLINICAL.Application.Dtos.TakeExam.Response;
using PROYECTOCLINICAL.Application.Interface.Interfaces;
using PROYECTOCLINICAL.Domain.Entities;
using PROYECTOCLINICAL.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
