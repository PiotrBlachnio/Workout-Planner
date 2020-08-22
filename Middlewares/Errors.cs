using System;

/**
 * 0 - Internal server error
 * 
 * 100 - Routine does not exist
 * 101 - Exercise does not exist
 */
namespace WorkoutPlanner.Middlewares {
    public class GenericError : Exception {
        public int Id = 0;
        public int StatusCode = 500;
        public new string Message = "Internal server error";
    }

    public class RoutineNotFoundError : GenericError {
        RoutineNotFoundError() {
            this.Id = 100;
            this.StatusCode = 404;
            this.Message = "Routine does not exist";
        }
    }
}