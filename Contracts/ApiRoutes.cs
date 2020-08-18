namespace NotesAPI.Contracts {
    public static class ApiRoutes {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Category {
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