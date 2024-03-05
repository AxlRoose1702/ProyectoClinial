using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisValidator : AbstractValidator<CreateAnalysisCommand>
    {
        public CreateAnalysisValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("No puede estar nulo.")
                .NotEmpty().WithMessage("No puede estar vacio.");
        }
    }
}
