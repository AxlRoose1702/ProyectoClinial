using FluentValidation;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Commands.CreateCommand
{
    public class CreateMedicValidator : AbstractValidator<CreateMedicCommand>
    {
        public CreateMedicValidator()
        {
            RuleFor(x => x.Names)
              .NotNull().WithMessage("El campo nombre no puede estar nulo")
              .NotEmpty().WithMessage("El campo nombre no puede estar vacio");

            RuleFor(x => x.LastName)
               .NotNull().WithMessage("El campo apellido no puede estar nulo")
               .NotEmpty().WithMessage("El campo apellido no puede estar vacio");

            RuleFor(x => x.MotherMaidenName)
               .NotNull().WithMessage("El campo apellido materno no puede estar nulo")
               .NotEmpty().WithMessage("El campo apellido materno no puede estar vacio");

            RuleFor(x => x.DocumentNumber)
               .NotNull().WithMessage("El campo No. documento no puede estar nulo")
               .NotEmpty().WithMessage("El campo No. documento no puede estar vacio")
               .Must(BeNumeric!).WithMessage("El campo No. documento debe contener solo numeros.");

            RuleFor(x => x.Phone)
               .NotNull().WithMessage("El campo telefono no puede estar nulo")
               .NotEmpty().WithMessage("El campo telefono no puede estar vacio")
               .Must(BeNumeric!).WithMessage("El campo telefono debe contener solo numeros.");
        }

        private bool BeNumeric(string input)
        {
            return int.TryParse(input, out _);
        }

    }
}

