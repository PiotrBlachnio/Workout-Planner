using FluentValidation;
using WorkoutPlanner.Database.Models;
using WorkoutPlanner.Errors;

namespace WorkoutPlanner.Database.Validators {
    public class ExerciseValidator : AbstractValidator<Exercise> {
        public ExerciseValidator() {
            RuleFor(exercise => exercise.Name)
                .NotEmpty().WithState(state => throw new GenericError(201, 400, "Name propety cannot be empty"))
                .MaximumLength(32).WithState(state => throw new GenericError(202, 400, "Name propety cannot be longer than 32 characters"));
            RuleFor(exercise => exercise.Muscle)
                .NotEmpty().WithState(state => throw new GenericError(201, 400, "Muscle propety cannot be empty"))
                .MaximumLength(16).WithState(state => throw new GenericError(202, 400, "Muscle property cannot be longer than 16 characters"));
            RuleFor(exercise => exercise.Sets)
                .GreaterThanOrEqualTo(1).WithState(state => throw new GenericError(203, 400, "Sets property cannot be less than 1"));
            RuleFor(exercise => exercise.Reps)
                .GreaterThanOrEqualTo(1).WithState(state => throw new GenericError(204, 400, "Reps property cannot be less than 1"));
            RuleFor(exercise => exercise.AdditionalWeight)
                .GreaterThanOrEqualTo(0).WithState(state => throw new GenericError(205, 400, "Additional weight property cannot be less than 0"));
            RuleFor(exercise => exercise.RestTime)
                .GreaterThanOrEqualTo(0).WithState(state => throw new GenericError(206, 400, "Rest time property cannot be less than 0"));
        }
    }
}