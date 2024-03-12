using MediatR;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Commands.CreateCommand
{
    public class CreateExamCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
        public int AnalysisId { get; set; }
    }
}
