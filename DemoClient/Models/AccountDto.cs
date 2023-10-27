using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoClient.Models
{
    public class AccountDto
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Fullname { get; set; }

        public int? Role { get; set; }
    }
}
