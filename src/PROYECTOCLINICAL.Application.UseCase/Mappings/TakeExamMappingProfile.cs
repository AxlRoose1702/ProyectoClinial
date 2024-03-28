using AutoMapper;
using PROYECTOCLINICAL.Application.Dtos.TakeExam.Response;
using PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.Command.CreateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.Command.UpdateCommand;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.Mappings
{
    public class TakeExamMappingProfile : Profile
    {
        public TakeExamMappingProfile()
        {
            CreateMap<GetTakeExamByIdResponseDto, TakeExam>()
                .ReverseMap();
            CreateMap<GetTakeExamDetailByTakeExamIdResponseDto, TakeExam>()
                .ReverseMap();
            CreateMap<CreateTakeExamCommand, TakeExam>();
            CreateMap<CreateTakeExamDetailCommand, TakeExamDetail>();

            CreateMap<UpdateTakeExamCommand, TakeExam>();
            CreateMap<UpdateTakeExamDetailCommand, TakeExamDetail>();

        }
    }
}
