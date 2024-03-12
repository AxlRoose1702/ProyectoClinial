using MediatR;
using PROYECTOCLINICAL.Application.Dtos.Exam.Response;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Queries.GetByIdQuery
{
    public class GetExamByIdQuery : IRequest<BaseResponse<GetExamByIdResponseDto>>
    {
        public int ExamId { get; set; }
    }
}
