using System;
using System.ComponentModel.DataAnnotations;

namespace WorkoutPlanner.Database.Models {
    public class Routine {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public long CreatedAt { get; set; }
    }
}