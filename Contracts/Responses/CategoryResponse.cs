using System;

namespace WorkoutPlanner.Contracts.Responses {
    public class CategoryResponse {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public long CreatedAt { get; set; }
    }
}