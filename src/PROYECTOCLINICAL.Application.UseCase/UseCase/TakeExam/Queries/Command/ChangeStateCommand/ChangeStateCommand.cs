using MediatR;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.Command.ChangeStateCommand
{
    public class ChangeStateCommand :IRequest<BaseResponse<bool>>
    {
        public int TakeExamId { get; set; }
        public int State { get; set; }
    }
}
