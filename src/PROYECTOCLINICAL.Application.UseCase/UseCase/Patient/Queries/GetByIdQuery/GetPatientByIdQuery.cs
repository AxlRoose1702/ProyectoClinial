using MediatR;
using PROYECTOCLINICAL.Application.Dtos.Patient.Response;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.GetByIdQuery
{
    public class GetPatientByIdQuery :IRequest<BaseResponse<GetPatientByIdResponseDto>>
    {
        public int PatientId { get; set; }
    }
}
