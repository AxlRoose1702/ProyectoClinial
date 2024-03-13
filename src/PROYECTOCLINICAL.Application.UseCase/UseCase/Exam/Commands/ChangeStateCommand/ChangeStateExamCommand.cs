using MediatR;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Commands.ChangeStateCommand
{
    public class ChangeStateExamCommand : IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
        public int State { get; set; }
    }
}
