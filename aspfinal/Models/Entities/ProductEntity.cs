using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspfinal.Models.Entities
{
    public class ProductEntity
    {

        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public int Rating { get; set; }

    }
}
