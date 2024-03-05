using MediatR;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
    }
}
