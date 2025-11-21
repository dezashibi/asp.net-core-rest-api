namespace Movies.Api;

public static class ApiEndpoints
{
    private const string API_BASE = "api";

    public static class Movies
    {
        private const string BASE = $"{API_BASE}/movies";

        public const string CREATE = BASE;
        public const string GET = $"{BASE}/{{id:guid}}";
        public const string GET_ALL = BASE;
    }
}