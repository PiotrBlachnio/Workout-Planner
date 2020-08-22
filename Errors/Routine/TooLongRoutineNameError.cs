namespace WorkoutPlanner.Errors.Routine {
    public class TooLongRoutineNameError : GenericError {
        public TooLongRoutineNameError() {
            this.Id = 102;
            this.StatusCode = 400;
            this.Message = "Routine's name is too long";
        }
    }
}