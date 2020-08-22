namespace WorkoutPlanner.Errors {
    public class TooLongRoutineNameError : GenericError {
        public TooLongRoutineNameError() {
            this.Id = 103;
            this.StatusCode = 400;
            this.Message = "Routine's name is too long";
        }
    }
}