using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Aiko.Requests.PointOfInterest;

namespace Teste_Aiko.Validations
{
    public class UpdatePointOfInterestValidator : AbstractValidator<UpdatePointOfInterestRequest>
    {
        public UpdatePointOfInterestValidator()
        {
            RuleFor(x => x.Coordinates)
                .NotNull().WithMessage("Informe as coordenadas.")
                .Matches(@"^-?(\d+\.\d+),-?(\d+\.\d+)(,\d+z?)?$").WithMessage("As coordenadas não estão no formato correto.");

            RuleFor(x => x.Description)
                .MaximumLength(120).WithMessage("A descrição pode ter no máximo {MaxLength} caracteres.");
        }
    }
}
