using Movies.Api.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;

namespace Movies.Api.Endpoints.Movies;

public static class CreateMovieEndpoint
{
    public const string NAME = "CreateMovie";

    public static IEndpointRouteBuilder MapCreateMovie(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Movies.CREATE, async (
                CreateMovieRequest request,
                IMovieService movieService,
                HttpContext context,
                CancellationToken token) =>
            {
                var movie = request.MapToMovie();

                await movieService.CreateAsync(movie, token);

                return TypedResults.CreatedAtRoute(movie.MapToResponse(), GetMovieEndpoint.NAME, new { idOrSlug = movie.Id });
            })
            .WithName(NAME);

        return app;
    }
}