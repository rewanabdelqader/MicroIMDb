using Microsoft.EntityFrameworkCore;
using MicroIMDb.Infrastructure.Repositories;
using AutoMapper;
using MicroIMDb.Application.Dtos.MovieDto;


namespace MicroIMDb.Application.Services.Movie
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Models.Movie> _repository;

        public MovieService(IMapper mapper, IRepository<Models.Movie> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Models.Movie> AddMovie(AddMovieDto movieDto)
        {
            if (movieDto == null)
            {
                throw new ArgumentNullException(nameof(movieDto), "Movie DTO cannot be null.");
            }

            var movie = _mapper.Map<Models.Movie>(movieDto);
            var response = await _repository.AddAsync(movie);

            if (response != null)
            {
                await _repository.SaveChangesAsync();
                return await _repository.GetByIdAsync(m=> m.Id == response.Id);
            }
            return null!;

        }

        public async Task<GetMovie?> GetMovieById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid movie ID.", nameof(id));
            }

            var movie = await _repository.GetByIdAsync(m => m.Id == id);
            if (movie != null && !movie.IsDeleted)
            {
                var movieDto = _mapper.Map<GetMovie>(movie);
                return movieDto;
            }
            return null;
        }

        public async Task<IEnumerable<GetAllMovies>> GetAllMovies()
        {
            var movies = await _repository.GetAllAsync(m => !m.IsDeleted);
            var movieDtos = _mapper.Map<IEnumerable<GetAllMovies>>(movies);
            return movieDtos;
        }

        public async Task<Models.Movie?> UpdateMovie(GetMovie movieDto)
        {
            if (movieDto == null)
            {
                throw new ArgumentNullException(nameof(movieDto), "Movie DTO cannot be null.");
            }

            var movie = await _repository.GetByIdAsync(m => m.Id == movieDto.Id);
            if (movie != null)
            {
                _mapper.Map(movieDto, movie);
                var response = await _repository.UpdateAsync(movie);

                if (response != null)
                {
                    await _repository.SaveChangesAsync();
                    return await _repository.GetByIdAsync(m => m.Id == response.Id);
                }
            }
            return null;
        }

        public async Task SoftDeleteMovie(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid movie ID.", nameof(id));
            }

            var movie = await _repository.GetByIdAsync(m => m.Id == id);
            if (movie != null)
            {
                movie.IsDeleted = true;
                await _repository.UpdateAsync(movie);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
