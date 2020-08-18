using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NotesAPI.Database.Models {
    public class Note {
        [Key]
        public int Guid { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [DefaultValue(new string[] {})]
        public List<string> Tags { get; set; }

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