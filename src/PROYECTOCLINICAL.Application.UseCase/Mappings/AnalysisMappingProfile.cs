using AutoMapper;
using PROYECTOCLINICAL.Application.Dtos.Analysis.Response;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Analysis.Commands.CreateCommand;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile() 
        {
            CreateMap<Analysis, GetAllAnalysisResponseDto>()
                .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
                .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();
        }
    }
}
