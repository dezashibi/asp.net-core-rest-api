using Movies.Api.Auth;
using Movies.Api.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;

namespace Movies.Api.Endpoints.Movies;

public static class GetAllMoviesEndpoint
{
    public const string NAME = "GetAllMovies";

    public static IEndpointRouteBuilder MapGetAllMovies(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Movies.GET_ALL, async (
                [AsParameters] GetAllMoviesRequest request,
                IMovieService movieService,
                HttpContext context,
                CancellationToken token
            ) =>
            {
                var userId = context.GetUserId();
                var options = request.MapToOptions()
                    .WithUser(userId);
                var movies = await movieService.GetAllAsync(options, token);
                var moviesCount = await movieService.GetCountAsync(options.Title, options.YearOfRelease, token);
                return Results.Ok(movies.MapToResponse(
                    request.Page.GetValueOrDefault(PagedRequest.DEFAULT_PAGE),
                    request.PageSize.GetValueOrDefault(PagedRequest.DEFAULT_PAGE_SIZE),
                    moviesCount
                ));
            })
            .WithName(NAME);

        return app;
    }
}