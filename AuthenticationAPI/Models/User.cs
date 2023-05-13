using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Models
{
    public class USer
    {
        [Key]
        public string Username { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? HashKey { get; set; }
        public string? Role { get; set; }
    }
}
