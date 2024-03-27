using MediatR;
using PROYECTOCLINICAL.Application.Dtos.TakeExam.Response;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.GetByIdQuery
{
    public class GetTakeExamByIdQuery : IRequest<BasePaginationResponse<IEnumerable<GetTakeExamByIdResponseDto>>>
    {
        public int TakeExamId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
