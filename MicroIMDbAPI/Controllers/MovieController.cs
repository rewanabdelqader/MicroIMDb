using MicroIMDb.Application.Dtos.MovieDto;
using MicroIMDb.Application.Services.Movie;
using MicroIMDb.Infrastrcture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MicroIMDb.API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GetMovie>> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound($"Movie with id {id} not found.");
            }

            return Ok(movie);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetAllMovies>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> AddMovie([FromBody] AddMovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedMovie = await _movieService.AddMovie(movie);
            if (addedMovie == null)
            {
                return StatusCode(500, "Failed to add the movie.");
            }

            return CreatedAtAction(nameof(GetMovieById), new { id = addedMovie.Id }, addedMovie);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> UpdateMovie(int id, [FromBody] GetMovie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest("Id in the URL does not match Id in the request body.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedMovie = await _movieService.UpdateMovie(movie);
            if (updatedMovie == null)
            {
                return StatusCode(500, "Failed to update the movie.");
            }

            return Ok(updatedMovie);
        }

        [HttpPut("soft-delete/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> SoftDeleteMovie(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound($"Movie with id {id} not found.");
            }

            await _movieService.SoftDeleteMovie(id);
            return Ok("Movie soft deleted successfully.");
        }      
    }
}

