using MediatR;
using PROYECTOCLINICAL.Application.Dtos.Patient.Response;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.GetAllQuery
{
    public class GetAllPatientQuery : IRequest<BaseResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
    }
}
