using FluentValidation;
using WorkoutPlanner.Database.Models;
using WorkoutPlanner.Errors;

namespace WorkoutPlanner.Database.Validators {
    public class RoutineValidator : AbstractValidator<Routine> {
        public RoutineValidator() {
            RuleFor(routine => routine.Name)
                .NotEmpty().WithState(state => throw new GenericError(101, 400, "Name property cannot be empty"))
                .MaximumLength(16).WithState(state => throw new GenericError(102, 400, "Name property cannot be longer than 16 characters"));
        }
    }
}