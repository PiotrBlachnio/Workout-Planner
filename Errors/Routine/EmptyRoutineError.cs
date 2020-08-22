namespace WorkoutPlanner.Errors.Routine {
    public class EmptyRoutineNameError : GenericError {
        public EmptyRoutineNameError() {
            this.Id = 101;
            this.StatusCode = 400;
            this.Message = "Routine's name cannot be empty";
        }
    }
}