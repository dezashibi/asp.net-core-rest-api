using Movies.Api.Auth;
using Movies.Application.Services;

namespace Movies.Api.Endpoints.Movies;

public static class DeleteMovieEndpoint
{
    public const string NAME = "DeleteMovie";

    public static IEndpointRouteBuilder MapDeleteMovie(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiEndpoints.Movies.DELETE, async (Guid id, IMovieService movieService, HttpContext context, CancellationToken token) =>
            {
                var deleted = await movieService.DeleteByIdAsync(id, token);

                return !deleted ? Results.NotFound() : Results.Ok();
            })
            .WithName(NAME)
            .RequireAuthorization(AuthConstants.ADMIN_USER_POLICY_NAME);

        return app;
    }
}