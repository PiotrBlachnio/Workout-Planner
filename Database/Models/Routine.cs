using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkoutPlanner.Database.Models {
    public class Routine {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        [DefaultValue(0)]
        public int ExercisesNumber { get; set; }
        
        public long CreatedAt { get; set; }
    }
}