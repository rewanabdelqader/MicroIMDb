

namespace MicroIMDb.Application.Dtos
{
    public class AddRatingDto
    {
        public string? userId { get; set; }
        public int movieId { get; set; }
        public decimal rating { get; set; }
    }
}
