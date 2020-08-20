using System;

namespace NotesAPI.Contracts.Responses {
    public class CategoryResponse {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public long CreatedAt { get; set; }
    }
}