

namespace MicroIMDb.Application.Dtos.MovieDto
{
    public class GetAllMovies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalRating { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
