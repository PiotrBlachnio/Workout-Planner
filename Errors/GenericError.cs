using System;

/**
 * 0 - Internal server error
 * 1 - Invalid input types
 * 
 *? Routine errors
 * 100 - Routine does not exist
 * 101 - Name property cannot be empty
 * 102 - Name property cannot be longer than 16 characters
 *
 *? Exercise errors
 * 200 - Exercise does not exist
 * 201 - Name propety cannot be empty
 * 202 - Name property cannot be longer than 32 characters
 * 203 - Muscle propety cannot be empty
 * 204 - Muscle property cannot be longer than 16 characters
 * 205 - Sets property cannot be less than 1
 * 206 - Reps property cannot be less than 1
 * 207 - Additional weight property cannot be less than 0
 * 208 - Rest time property cannot be less than 0
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