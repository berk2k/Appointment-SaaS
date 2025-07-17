using AppointmentSystem.Application.Commands.Appointment;
using FluentValidation;

namespace AppointmentSystem.Application.Validators
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(x => x.TenantId).NotEmpty();
            RuleFor(x => x.BranchId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();

            RuleFor(x => x.StartTime).NotEmpty();
            RuleFor(x => x.EndTime)
                .NotEmpty()
                .GreaterThan(x => x.StartTime)
                .WithMessage("EndTime must be greater than StartTime.");

            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
