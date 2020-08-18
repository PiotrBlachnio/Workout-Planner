using System;

namespace NotesAPI {
    public static class Utils {
        public static long GetCurrentDate() {
            return Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1970, 1,1)).TotalMilliseconds);
        }
    }
}