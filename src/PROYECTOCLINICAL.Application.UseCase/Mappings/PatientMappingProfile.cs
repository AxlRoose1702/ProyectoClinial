using AutoMapper;
using PROYECTOCLINICAL.Application.Dtos.Patient.Response;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.Command.ChangeStateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.Command.CreateCommand;
using PROYECTOCLINICAL.Application.UseCase.UseCase.Patient.Queries.Command.UpdateCommand;
using PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, GetPatientByIdResponseDto>()
                .ReverseMap();
            CreateMap<CreatePatientCommand, Patient>();
            CreateMap<UpdatePatientCommand, Patient>();
            CreateMap<ChangeStatePatientCommand, Patient>();
        }
    }
}
