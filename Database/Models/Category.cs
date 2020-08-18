using System;
using System.ComponentModel.DataAnnotations;

namespace NotesAPI.Database.Models {
    public class Category {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public long CreatedAt { get; set; }
    }
}