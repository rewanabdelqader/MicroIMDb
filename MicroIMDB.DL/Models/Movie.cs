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
        public decimal TotalRating { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Rate> Rates { get; set; } = new List<Rate>();
    }
}