using MediatR;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.Command.CreateCommand
{
    public class CreateTakeExamCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }
        public int MedicId { get; set; }
        public IEnumerable<CreateTakeExamDetailCommand> TakeExamDetails { get; set; } = null;
    }

    public class CreateTakeExamDetailCommand
    {
        public int ExamId { get; set; }
        public int AnalysisId { get; set; }
    }
}
