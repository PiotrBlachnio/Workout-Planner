using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutPlanner.Database.Models {
    public class Exercise {
        [Key]
        public Guid Id { get; set; }
        
        public Guid RoutineId { get; set; }

        [ForeignKey(nameof(RoutineId))]
        public Routine Routine { get; set; }

        public string Name { get; set; }
        
        public string Muscle { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public int AdditionalWeight { get; set; }

        public int RestTime { get; set; }

        public string Notes { get; set; }
        
        public long CreatedAt { get; set; }
    }
}