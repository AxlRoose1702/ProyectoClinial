using PROYECTOCLINICAL.Application.Dtos.Medic.Response;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.Interface.Interfaces
{
    public interface IMedicRepository : IGenericRepository<Medic>
    {
        Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedic(string storeProcedure, object parameter);
    }
}
