﻿namespace PROYECTOCLINICAL.Application.Dtos.Medic.Response
{
    public class GetAllMedicResponseDto
    {
        public int? MedicId { get; set; }
        public string? Names { get; set; }
        public string? Surnames { get; set; }
        public string? Speciality { get; set; }
        public string? DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? BirthDate { get; set; }
        public string? StateMedic { get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}
