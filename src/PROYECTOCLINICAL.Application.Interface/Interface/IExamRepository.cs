using PROYECTOCLINICAL.Application.Dtos.Exam.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCLINICAL.Application.Interface.Interface
{
    public interface IExamRepository
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure);
    }
}
