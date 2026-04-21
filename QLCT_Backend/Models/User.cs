using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")] // Khớp với tên bảng trong SQL của bạn
public class User {
    [Key]
    public long Id { get; set; }

    [Column("full_name")] // Mapping với tên cột full_name
    public string FullName { get; set; }

    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } = "USER";
}