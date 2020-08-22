using FluentValidation;
using WorkoutPlanner.Database.Models;
using WorkoutPlanner.Errors;

namespace WorkoutPlanner.Database.Validators {
    public class ExerciseValidator : AbstractValidator<Exercise> {
        public ExerciseValidator() {
            RuleFor(exercise => exercise.Name)
                .NotEmpty().WithState(state => throw new GenericError(201, 400, "Exercise's name cannot be empty"))
                .MaximumLength(32).WithState(state => throw new GenericError(202, 400, "Exercise's name is too long"));
            RuleFor(exercise => exercise.Muscle)
                .NotEmpty().WithState(state => throw new GenericError(201, 400, "Exercise's name cannot be empty"))
                .MaximumLength(16).WithState(state => throw new GenericError(202, 400, "Exercise's name is too long"));
        }
    }
}