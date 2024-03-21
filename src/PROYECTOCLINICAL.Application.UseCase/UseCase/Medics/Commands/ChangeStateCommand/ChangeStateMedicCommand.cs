using MediatR;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Commands.ChangeStateCommand
{
    public class ChangeStateMedicCommand : IRequest<BaseResponse<bool>>
    {
        public int MedicId { get; set; }
        public int State { get; set; }
    }
}
