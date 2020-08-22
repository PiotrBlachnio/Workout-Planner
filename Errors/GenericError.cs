using System;

/**
 * 0 - Internal server error
 * 
 *? Routine errors
 * 100 - Routine does not exist
 * 101 - Routine's name cannot be empty
 * 102 - Routine's name is too long
 *
 *? Exercise errors
 * 200 - Exercise does not exist
 */
 
namespace WorkoutPlanner.Errors {
    public class GenericError : Exception {
        public int Id = 0;
        public int StatusCode = 500;
        public new string Message = "Internal server error";
    }
}