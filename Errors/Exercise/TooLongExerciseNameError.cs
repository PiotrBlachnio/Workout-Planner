namespace WorkoutPlanner.Errors.Exercise {
    public class TooLongExerciseNameError : GenericError {
        public TooLongExerciseNameError() {
            this.Id = 202;
            this.StatusCode = 400;
            this.Message = "Exercise's name is too long";
        }
    }
}