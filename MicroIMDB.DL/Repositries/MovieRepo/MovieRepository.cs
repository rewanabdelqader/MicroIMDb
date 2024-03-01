using MicroIMDb.Infrastrcture.Repositries.MovieRepo;
using MicroIMDb.Models;
using MicroIMDb.Persistence;
using Microsoft.EntityFrameworkCore;


namespace MicroIMDb.Infrastructure.Repositories.MovieRepo
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MicroIMDbDbContext context) : base(context)
        {
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return null;
            }
            return movie;
        }

        public async Task<bool> RateMovie(string userId, int movieId, decimal rating)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null)
            {
                // Movie not found
                return false;
            }

            // Check if the user has already rated the movie
            var existingRating = movie.Rates.FirstOrDefault(r => r.UserId == userId && r.MovieId == movieId);

            if (existingRating != null)
            {
                // If the user has already rated the movie, update the rating
                existingRating.Rating = rating;
            }
            else
            {
                // If the user has not rated the movie, add a new rating
                var rate = new Rate
                {
                    UserId = userId,
                    MovieId = movieId,
                    Rating = rating
                };
                var newRateing = await _context.Rates.AddAsync(rate);
                await _context.SaveChangesAsync();
            }
            movie.TotalRating = (movie.Rates.Where(x => x.MovieId == movie.Id).Any() ? (movie.Rates.Sum(r => r.Rating) / (movie.Rates.Count)) * 100 : 0); _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
