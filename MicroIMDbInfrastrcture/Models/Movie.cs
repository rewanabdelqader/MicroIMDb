using System.ComponentModel.DataAnnotations;

namespace MicroIMDb.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string TotalRating { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}