using MediatR;
using PROYECTOCLINICAL.Application.Dtos.Patient.Response;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.GetAllQuery
{
    public class GetAllPatientQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
