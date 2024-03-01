using System.ComponentModel.DataAnnotations;


namespace MicroIMDb.Application.Dtos.MovieDto
{
    public class AddMovieDto
    {

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

    }
}
