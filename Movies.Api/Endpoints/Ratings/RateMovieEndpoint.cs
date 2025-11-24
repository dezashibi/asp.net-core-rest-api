using Movies.Api.Auth;
using Movies.Application.Services;
using Movies.Contracts.Requests;

namespace Movies.Api.Endpoints.Ratings;

public static class RateMovieEndpoint
{
    public const string NAME = "RateMovie";

    public static IEndpointRouteBuilder MapRateMovie(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiEndpoints.Movies.RATE, async (Guid id, RateMovieRequest request, IRatingService ratingService, HttpContext context, CancellationToken token) =>
            {
                var userId = context.GetUserId();
                var result = await ratingService.RateMovieAsync(id, request.Rating, userId!.Value, token);

                return result ? Results.Ok() : Results.NotFound();
            })
            .WithName(NAME)
            .RequireAuthorization();

        return app;
    }
}