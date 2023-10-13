using FluentValidation;

namespace Clinic.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class EditAnalysisValidator : AbstractValidator<EditAnalysisCommand>
    {
        public EditAnalysisValidator()
        {
            RuleFor(x => x.NameAnalysis)
                .NotNull().WithMessage("EL campo nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no pyede estar vacio");
        }
    }
}
