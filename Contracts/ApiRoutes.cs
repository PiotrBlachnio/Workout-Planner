namespace WorkoutPlanner.Contracts {
    public static class ApiRoutes {
        private const string Root = "api";

        private const string Version = "v1";

        private const string Base = Root + "/" + Version;

        public static class Category {
            public const string Get = Base + "/category/{id}";
            
            public const string GetAll = Base + "/category";

            public const string Create = Base + "/category";

            public const string Delete = Base + "/category/{id}";

            public const string Update = Base + "/category/{id}";
        }

        public static class Note {
            public const string GetAll = Base + "/note";

            public const string Create = Base + "/note";

            public const string Delete = Base + "/note/{id}";

            public const string Update = Base + "/note/{id}";
        }
    }
}