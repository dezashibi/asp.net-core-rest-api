using Movies.Contracts.Requests;
using Movies.Contracts.Responses;
using Refit;

namespace Movies.Api.Sdk;

[Headers("Authorization: Bearer")]
public interface IMoviesApi
{
    [Get(ApiEndpoints.Movies.GET)]
    Task<MovieResponse> GetMovieAsync(string idOrSlug);

    [Get(ApiEndpoints.Movies.GET_ALL)]
    Task<MoviesResponse> GetMoviesAsync(GetAllMoviesRequest request);

    [Post(ApiEndpoints.Movies.CREATE)]
    Task<MovieResponse> CreateMovieAsync(CreateMovieRequest request);

    [Put(ApiEndpoints.Movies.UPDATE)]
    Task<MovieResponse> UpdateMovieAsync(Guid id, UpdateMovieRequest request);

    [Delete(ApiEndpoints.Movies.DELETE)]
    Task DeleteMovieAsync(Guid id);

    [Put(ApiEndpoints.Movies.RATE)]
    Task RateMovieAsync(Guid id, RateMovieRequest request);

    [Delete(ApiEndpoints.Movies.DELETE_RATING)]
    Task DeleteRatingAsync(Guid id);

    [Get(ApiEndpoints.Ratings.GET_USER_RATINGS)]
    Task<IEnumerable<MovieRatingResponse>> GetUserRatingsAsync();
}