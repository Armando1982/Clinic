using Clinic.Utilities.Constants;
using FluentValidation;

namespace Clinic.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamValidator : AbstractValidator<CreateExamCommand>
    {
        public CreateExamValidator()
        {
            RuleFor(x => x.NameExam)
                .NotNull().WithMessage(GlobalMessages.VALIDATOR_NOT_NULL)
                .NotEmpty().WithMessage(GlobalMessages.VALIDATOR_NOT_EMPTY);

        }
    }
}
