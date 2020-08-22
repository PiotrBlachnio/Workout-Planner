using FluentValidation;
using WorkoutPlanner.Database.Models;
using WorkoutPlanner.Errors.Exercise;
using WorkoutPlanner.Errors.Routine;

namespace WorkoutPlanner.Database.Validators {
    public class ExerciseValidator : AbstractValidator<Exercise> {
        public ExerciseValidator() {
            RuleFor(exercise => exercise.Name)
                .NotEmpty().WithState(state => throw new EmptyExerciseNameError())
                .MaximumLength(32).WithState(state => throw new TooLongRoutineNameError());
        }
    }
}