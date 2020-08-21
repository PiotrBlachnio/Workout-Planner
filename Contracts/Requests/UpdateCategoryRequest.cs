namespace WorkoutPlanner.Contracts.Requests {
    public class UpdateCategoryRequest {
        public string Name { get; set; }
        
        public long CreatedAt { get; set; }
    }
}