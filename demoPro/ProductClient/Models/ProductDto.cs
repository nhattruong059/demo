using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductClient.Models
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public int? Price { get; set; }
    }
}
