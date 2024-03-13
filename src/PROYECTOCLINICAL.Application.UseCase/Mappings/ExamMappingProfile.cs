using AutoMapper;
using PROYECTOCLINICAL.Application.Dtos.Exam.Response;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Commands.ChangeStateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Commands.CreateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Commands.UpdateCommand;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.Mappings
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, GetExamByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateExamCommand, Exam>();
            CreateMap<UpdateExamCommand, Exam>();
            CreateMap<ChangeStateExamCommand, Exam>();
        }
    }
}
