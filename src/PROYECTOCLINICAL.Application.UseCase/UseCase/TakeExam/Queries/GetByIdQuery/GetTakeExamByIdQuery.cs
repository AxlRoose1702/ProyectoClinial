using MediatR;
using PROYECTOCLINICAL.Application.Dtos.TakeExam.Response;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.GetByIdQuery
{
    public class GetTakeExamByIdQuery : IRequest<BaseResponse<GetTakeExamByIdResponseDto>>
    {
        public int TakeExamId { get; set; }
    }
}
