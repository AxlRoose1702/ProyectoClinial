using MediatR;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Commands.DeleteCommand
{
    public class DeleteMedicCommand : IRequest<BaseResponse<bool>>
    {
        public int MedicId { get; set; }
    }
}
