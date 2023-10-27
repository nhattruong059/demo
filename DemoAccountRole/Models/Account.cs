using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAccountRole.Models
{
    public class Account
    {
        [Key]
        [Column(TypeName ="nvarchar")]
        [StringLength(200)]
        public string? Email { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        public string? Password { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string? Fullname { get; set; }

        public int? Role { get; set; }


    }
}
