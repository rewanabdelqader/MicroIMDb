using MicroIMDb.Application.Dtos;
using MicroIMDb.Application.Services.Rate;
using MicroIMDb.Infrastrcture.Repositries.MovieRepo;
using MicroIMDb.Infrastrcture.Repositries.UserRepo;
using MicroIMDb.Infrastructure.Repositories;


namespace MicroIMDb.Application.Services.Rating
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Models.Rate> _repository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepositry _userRepositry;

        public RatingService(IRepository<Models.Rate> repository , IMovieRepository movieRepository , IUserRepositry userRepositry)
        {
            _repository = repository;
            _movieRepository = movieRepository;
            _userRepositry = userRepositry;
        }

        public async Task<bool> RateMovie(AddRatingDto addRatingDto)
        {

            //var movie = await _movieRepository.GetMovieById(addRatingDto.movieId);
            ////var movie = await _context.Movies.Include(m => m.Rates).FirstOrDefaultAsync(m => m.Id == movieId);

            //if (movie == null)
            //{
            //    // Movie not found
            //    return false;
            //}

            //// Check if the user has already rated the movie
            //var existingRating = movie.Rates.FirstOrDefault(r => r.UserId == addRatingDto.userId);

            //if (existingRating != null)
            //{
            //    // If the user has already rated the movie, update the rating
            //    existingRating.Rating = addRatingDto.rating;
            //    await _repository.UpdateAsync(existingRating);
            //    await _repository.SaveChangesAsync();
            //}
            //else
            //{
            //    // If the user has not rated the movie, add a new rating
            //    var rate = new Models.Rate
            //    {
            //        UserId = addRatingDto.userId,
            //        MovieId = addRatingDto.movieId,
            //        Rating = addRatingDto.rating
            //    };
            //    await _repository.AddAsync(rate);
            //    await _repository.SaveChangesAsync();
            //}

            // Recalculate total rating
            var totalReating = await _movieRepository.RateMovie(addRatingDto.userId, addRatingDto.movieId , addRatingDto.rating);
            if (totalReating is true )
            {
                return true;

            }
            //movie.TotalRating = movie.Rates.Any() ? movie.Rates.Average(r => r.Rating) : 0;
            return false;
        }

    }
}
