namespace WorkoutPlanner.Errors.Exercise {
    public class EmptyExerciseNameError : GenericError {
        public EmptyExerciseNameError() {
            this.Id = 201;
            this.StatusCode = 400;
            this.Message = "Exercise's name cannot be empty";
        }
    }
}