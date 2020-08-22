namespace WorkoutPlanner.Errors {
    public class ExerciseNotFoundError : GenericError {
        public ExerciseNotFoundError() {
            this.Id = 101;
            this.StatusCode = 404;
            this.Message = "Exercise does not exist";
        }
    }
}