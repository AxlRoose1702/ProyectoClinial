using Dapper;
using PROYECTOCLINICAL.Application.Dtos.Patient.Response;
using PROYECTOCLINICAL.Application.Interface.Interfaces;
using PROYECTOCLINICAL.Domain.Entities;
using PROYECTOCLINICAL.Persistence.Context;
using System.Data;

namespace PROYECTOCLINICAL.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatients(string storeProcedure)
        {
            using var connection = _context.CreateConnection;
            var patients = await connection.QueryAsync<GetAllPatientResponseDto>(storeProcedure, commandType: CommandType.StoredProcedure);
            return patients;
        }

    }
}
