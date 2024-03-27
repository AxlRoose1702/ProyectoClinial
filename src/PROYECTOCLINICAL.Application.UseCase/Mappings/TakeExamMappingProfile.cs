using AutoMapper;
using PROYECTOCLINICAL.Application.Dtos.TakeExam.Response;
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
        }
    }
}
