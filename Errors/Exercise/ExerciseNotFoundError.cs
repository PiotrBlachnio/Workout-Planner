namespace WorkoutPlanner.Errors.Exercise {
    public class ExerciseNotFoundError : GenericError {
        public ExerciseNotFoundError() {
            this.Id = 200;
            this.StatusCode = 404;
            this.Message = "Exercise does not exist";
        }
    }
}