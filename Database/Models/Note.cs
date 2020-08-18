using System.Collections.Generic;

namespace NotesAPI.Database.Models {
    public class Note {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public List<string> Tags { get; set; }
        public int CreatedAt { get; set; }
        public int LastEditedAt { get; set; }
        public int OwnerId { get; set; }
        public bool IsPrivate { get; set; }
    }
}