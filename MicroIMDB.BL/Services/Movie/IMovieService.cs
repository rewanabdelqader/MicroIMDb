using MicroIMDb.Application.Dtos.MovieDto;
using System.Threading.Tasks;

namespace MicroIMDb.Application.Services.Movie
{
    public interface IMovieService
    {
        Task<GetMovie?> GetMovieById(int id);
        Task<Models.Movie> AddMovie(AddMovieDto movie);
        Task<Models.Movie> UpdateMovie(GetMovie movie);
        Task SoftDeleteMovie(int id);
        Task<IEnumerable<GetAllMovies>> GetAllMovies();

    }
}
