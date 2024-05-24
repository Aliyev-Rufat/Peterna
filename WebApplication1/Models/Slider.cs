
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string? ImgUrl { get; set; }

        [NotMapped]

        public IFormFile PhotoFile { get; set; }
    }
}
