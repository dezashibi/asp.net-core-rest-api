using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Movies.Contracts.Requests;
using Refit;

namespace Movies.Api.Sdk.Consumer;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        services
            .AddHttpClient()
            .AddSingleton<AuthTokenProvider>()
            .AddRefitClient<IMoviesApi>(s => new RefitSettings
            {
                AuthorizationHeaderValueGetter = async (message, token) => await s.GetRequiredService<AuthTokenProvider>().GetTokenAsync()
            })
            .ConfigureHttpClient(x => x.BaseAddress = new Uri("http://localhost:5074"));

        var provider = services.BuildServiceProvider();
        var moviesApi = provider.GetRequiredService<IMoviesApi>();

        var movie = await moviesApi.GetMovieAsync("some-movie-name-2023");
        Console.WriteLine(JsonSerializer.Serialize(movie));

        var req = new GetAllMoviesRequest
        {
            Title = null,
            Year = null,
            SortBy = null,
            Page = 1,
            PageSize = 3
        };
        var movies = await moviesApi.GetMoviesAsync(req);
        Console.WriteLine(JsonSerializer.Serialize(movies));
    }
}