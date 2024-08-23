using System.ComponentModel.DataAnnotations.Schema;

namespace BooksStore.Models
{
    public class Book
    {
        public long BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public string Genre { get; set; }
    }
}
