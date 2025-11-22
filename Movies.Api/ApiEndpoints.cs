namespace Movies.Api;

public static class ApiEndpoints
{
    private const string API_BASE = "api";

    public static class Movies
    {
        private const string BASE = $"{API_BASE}/movies";

        public const string CREATE = BASE;
        public const string GET = $"{BASE}/{{idOrSlug}}";
        public const string GET_ALL = BASE;
        public const string UPDATE = $"{BASE}/{{id:guid}}";
        public const string DELETE = $"{BASE}/{{id:guid}}";

        public const string RATE = $"{BASE}/{{id:guid}}/ratings";
        public const string DELETE_RATING = $"{BASE}/{{id:guid}}/ratings";
    }

    public static class Ratings
    {
        private const string BASE = $"{API_BASE}/ratings";

        public const string GET_USER_RATINGS = $"{BASE}/me";
    }
}