

namespace MicroIMDb.Application.Dtos.MovieDto
{
    public class GetMovie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;
        public decimal TotalRating { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
