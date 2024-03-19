using MediatR;
using PROYECTOCLINICAL.Application.Dtos.Medic.Response;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Queries.GetAllQuery
{
    public class GetAllMedicQuery : IRequest<BaseResponse<IEnumerable<GetAllMedicResponseDto>>>
    {
    }
}