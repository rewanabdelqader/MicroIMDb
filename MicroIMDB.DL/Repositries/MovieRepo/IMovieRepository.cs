using MicroIMDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroIMDb.Infrastrcture.Repositries.MovieRepo
{
    public interface IMovieRepository
    {
        Task<Movie?> GetMovieById(int id);
        Task<bool> RateMovie(string userId, int movieId, decimal rating);
    }
}
