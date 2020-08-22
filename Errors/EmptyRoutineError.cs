namespace WorkoutPlanner.Errors {
    public class EmptyRoutineError : GenericError {
        public EmptyRoutineError() {
            this.Id = 102;
            this.StatusCode = 400;
            this.Message = "Routine cannot be empty";
        }
    }
}