using AutoMapper;
using PROYECTOCLINICAL.Application.Dtos.Medic.Response;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.Mappings
{
    public class MedicMappingProfile : Profile
    {
        public MedicMappingProfile()
        {
            CreateMap<Medic, GetMedicByIdResponseDto>()
                .ReverseMap();
        }
    }
}