using Dapper;
using PROYECTOCLINICAL.Application.Dtos.Medic.Response;
using PROYECTOCLINICAL.Application.Interface.Interfaces;
using PROYECTOCLINICAL.Domain.Entities;
using PROYECTOCLINICAL.Persistence.Context;
using System.Data;

namespace PROYECTOCLINICAL.Persistence.Repositories
{
    public class MedicRepository : GenericRepository<Medic>, IMedicRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedic(string storeProcedure)
        {
            var conection = _context.CreateConnection;
            var medics = await conection.QueryAsync<GetAllMedicResponseDto>(storeProcedure, commandType: CommandType.StoredProcedure);
            return medics;
        }
    }
}
