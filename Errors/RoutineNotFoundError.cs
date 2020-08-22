namespace WorkoutPlanner.Errors {
    public class RoutineNotFoundError : GenericError {
        RoutineNotFoundError() {
            this.Id = 100;
            this.StatusCode = 404;
            this.Message = "Routine does not exist";
        }
    }
}