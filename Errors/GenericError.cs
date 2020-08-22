using System;

/**
 * 0 - Internal server error
 * 1 - Invalid input types
 * 
 *? Routine errors
 * 100 - Routine does not exist
 * 101 - Routine's name cannot be empty
 * 102 - Routine's name is too long
 *
 *? Exercise errors
 * 200 - Exercise does not exist
 * 201 - Exercise's name cannot be empty
 * 202 - Exercise's name is too long
 */
 
namespace WorkoutPlanner.Errors {
    public class GenericError : Exception {
        public int Id = 0;
        public int StatusCode = 500;
        public new string Message = "Internal server error";

        public GenericError(int id = 0, int statusCode = 500, string message = "Internal server error") {
            this.Id = id;
            this.StatusCode = statusCode;
            this.Message = message;
        }
    }
}