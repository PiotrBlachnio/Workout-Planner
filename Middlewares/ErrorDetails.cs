using Newtonsoft.Json;

namespace NotesAPI.Middlewares {
    public class ErrorDetails {
        public string message { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}