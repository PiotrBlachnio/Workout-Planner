using System;

namespace NotesAPI {
    public static class Utils {
        public static int GetCurrentDate() {
            return (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
    }
}