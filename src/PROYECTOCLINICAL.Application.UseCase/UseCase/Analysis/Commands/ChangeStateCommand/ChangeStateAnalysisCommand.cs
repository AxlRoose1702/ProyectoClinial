using MediatR;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
        public int State {  get; set; }
    }
}
