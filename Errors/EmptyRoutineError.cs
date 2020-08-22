namespace WorkoutPlanner.Errors {
    public class EmptyRoutineNameError : GenericError {
        public EmptyRoutineNameError() {
            this.Id = 102;
            this.StatusCode = 400;
            this.Message = "Routine's name cannot be empty";
        }
    }
}