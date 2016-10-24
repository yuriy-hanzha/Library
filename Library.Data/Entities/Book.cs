using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class Book : IdableEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }

        public int? PublishingYear { get; set; }
        public string PublishingHouse { get; set; }
    }
}
