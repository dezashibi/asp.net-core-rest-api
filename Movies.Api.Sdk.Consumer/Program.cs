using System.Text.Json;
using Movies.Contracts.Requests;
using Refit;

namespace Movies.Api.Sdk.Consumer;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var moviesApi = RestService.For<IMoviesApi>("http://localhost:5074");

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