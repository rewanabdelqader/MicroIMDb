using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroIMDb.Models
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }

        public decimal Rating { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
