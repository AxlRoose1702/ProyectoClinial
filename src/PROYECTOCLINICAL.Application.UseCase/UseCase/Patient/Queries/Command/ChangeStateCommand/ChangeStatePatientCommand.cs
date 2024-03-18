using MediatR;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.Command.ChangeStateCommand
{
    public class ChangeStatePatientCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }
        public int State {  get; set; }
    }
}
