using System;

namespace NotesAPI.Utils {
    public static class DateUtils {
        public static long GetCurrentDate() {
            return Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1970, 1,1)).TotalMilliseconds);
        }
    }
}