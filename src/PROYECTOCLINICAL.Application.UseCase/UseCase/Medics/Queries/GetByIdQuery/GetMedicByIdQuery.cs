using MediatR;
using PROYECTOCLINICAL.Application.Dtos.Medic.Response;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Queries.GetByIdQuery
{
    public class GetMedicByIdQuery : IRequest<BaseResponse<GetMedicByIdResponseDto>>
    {
        public int MedicId { get; set; }
    }
}
