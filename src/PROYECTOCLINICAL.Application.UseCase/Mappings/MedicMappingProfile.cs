using AutoMapper;
using PROYECTOCLINICAL.Application.Dtos.Medic.Response;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Commands.CreateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Commands.UpdateCommand;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.Mappings
{
    public class MedicMappingProfile : Profile
    {
        public MedicMappingProfile()
        {
            CreateMap<Medic, GetMedicByIdResponseDto>()
                .ReverseMap();
            CreateMap<CreateMedicCommand, Medic>();
            CreateMap<UpdateMedicCommand, Medic>();
        }
    }
}