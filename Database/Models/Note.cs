using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutPlanner.Database.Models {
    public class Note {
        [Key]
        public int Guid { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [NotMapped]
        public IEnumerable Tags { get; set; }

        [Required]
        public long CreatedAt { get; set; }

        [Required]
        public long LastEditedAt { get; set; }

        [Required]
        public int OwnerId { get; set; }
        
        [DefaultValue(true)]
        public bool IsPrivate { get; set; }
    }
}