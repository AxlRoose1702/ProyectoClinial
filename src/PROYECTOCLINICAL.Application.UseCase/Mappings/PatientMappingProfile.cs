using AutoMapper;
using PROYECTOCLINICAL.Application.Dtos.Patient.Response;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, GetPatientByIdResponseDto>()
                .ReverseMap();
        }
    }
}
