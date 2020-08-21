namespace WorkoutPlanner.Contracts {
    public static class ApiRoutes {
        private const string Root = "api";

        private const string Version = "v1";

        private const string Base = Root + "/" + Version;

        public static class Routine {
            public const string Get = Base + "/routine/{id}";
            
            public const string GetAll = Base + "/routine";

            public const string Create = Base + "/routine";

            public const string Delete = Base + "/routine/{id}";

            public const string Update = Base + "/routine/{id}";
        }

        public static class Exercise {
            public const string Get = Base + "/exercise/{id}";

            public const string GetAll = Base + "/exercise";

            public const string Create = Base + "/exercise";

            public const string Delete = Base + "/exercise/{id}";

            public const string Update = Base + "/exercise/{id}";
        }
    }
}