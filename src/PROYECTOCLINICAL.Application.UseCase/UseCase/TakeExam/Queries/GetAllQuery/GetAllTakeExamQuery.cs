using MediatR;
using PROYECTOCLINICAL.Application.Dtos.TakeExam.Response;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.GetAllQuery
{
    public class GetAllTakeExamQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
