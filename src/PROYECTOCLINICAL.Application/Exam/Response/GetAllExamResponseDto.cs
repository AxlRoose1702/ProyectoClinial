using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCLINICAL.Application.Dtos.Exam.Response
{
    public class GetAllExamResponseDto
    {
        public int ExamId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string StateExame { get; set; }
    }
}
