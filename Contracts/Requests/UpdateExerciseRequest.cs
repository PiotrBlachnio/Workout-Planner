namespace WorkoutPlanner.Contracts.Requests {
    public class UpdateExerciseRequest {     
        public string Name { get; set; }
    
        public string Muscle { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public int AdditionalWeight { get; set; }

        public int RestTime { get; set; }

        public string Notes { get; set; }
    }
}