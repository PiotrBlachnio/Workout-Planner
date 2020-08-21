using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutPlanner.Database.Models {
    public class Exercise {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public Guid RoutineId { get; set; }

        [ForeignKey(nameof(RoutineId))]
        public Routine Routine { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Muscle { get; set; }

        [Required]
        public int Sets { get; set; }

        [Required]
        public int Reps { get; set; }

        [Required]
        public int AdditionalWeight { get; set; }

        [Required]
        public int RestTime { get; set; }

        public string Notes { get; set; }

        [Required]
        public long CreatedAt { get; set; }
    }
}