using System.ComponentModel.DataAnnotations;

namespace MicroIMDb.Models
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
