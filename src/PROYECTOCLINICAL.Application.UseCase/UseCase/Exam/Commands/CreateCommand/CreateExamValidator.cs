using FluentValidation;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Commands.CreateCommand
{
    public class CreateExamValidator : AbstractValidator<CreateExamCommand>
    {
        public CreateExamValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo nombre no puede estar nulo")
                .NotEmpty().WithMessage("El campo nombre no puede estar vacio");
        }
    }
}
