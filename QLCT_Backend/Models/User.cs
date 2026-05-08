using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCT_Backend.Models
{
    [Table("users")]
    public class User 
    {
        [Key]
        public long Id { get; set; }

        [Column("full_name")]
        public string? FullName { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
        
        public string? Password { get; set; }
        
        public string Role { get; set; } = "USER";
    }
}