using PROYECTOCLINICAL.Application.Dtos.Medic.Response;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCLINICAL.Application.Interface.Interfaces
{
    public interface IMedicRepository : IGenericRepository<Medic>
    {
        Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedics(string storeProcedure);
    }
}
