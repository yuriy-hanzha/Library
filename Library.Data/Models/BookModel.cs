using System.ComponentModel.DataAnnotations;

namespace Library.Data.DTOs
{
    public class BookModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }

        public int? PublishingYear { get; set; }
        public string PublishingHouse { get; set; }
    }
}
