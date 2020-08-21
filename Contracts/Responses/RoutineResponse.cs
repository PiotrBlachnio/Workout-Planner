using System;

namespace WorkoutPlanner.Contracts.Responses {
    public class RoutineResponse {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public long CreatedAt { get; set; }
    }
}