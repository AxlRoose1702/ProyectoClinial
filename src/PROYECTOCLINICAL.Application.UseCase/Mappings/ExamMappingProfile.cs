using AutoMapper;
using PROYECTOCLINICAL.Application.Dtos.Exam.Response;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.Mappings
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, GetExamByIdResponseDto>()
                .ReverseMap();
        }
    }
}
