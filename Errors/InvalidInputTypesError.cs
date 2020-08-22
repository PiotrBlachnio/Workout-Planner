namespace WorkoutPlanner.Errors {
    public class InvalidInputTypesError : GenericError {
        public InvalidInputTypesError() {
            this.Id = 1;
            this.StatusCode = 400;
            this.Message = "Invalid input types";
        }
    }
}