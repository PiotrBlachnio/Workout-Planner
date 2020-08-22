using FluentValidation;
using WorkoutPlanner.Database.Models;
using WorkoutPlanner.Errors;

namespace WorkoutPlanner.Database.Validators {
    public class RoutineValidator : AbstractValidator<Routine> {
        public RoutineValidator() {
            RuleFor(routine => routine.Name).NotEmpty().WithState(state => throw new EmptyRoutineError());
        }
    }
}