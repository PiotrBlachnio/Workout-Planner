using System;

/**
 * 0 - Internal server error
 * 
 * 100 - Routine does not exist
 * 101 - Exercise does not exist
 * 102 - Routine's name cannot be empty
 * 103 - Routine's name is too long
 */
 
namespace WorkoutPlanner.Errors {
    public class GenericError : Exception {
        public int Id = 0;
        public int StatusCode = 500;
        public new string Message = "Internal server error";
    }
}