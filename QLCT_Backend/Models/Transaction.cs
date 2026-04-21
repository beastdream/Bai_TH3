using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("transactions")]
public class Transaction {
    [Key]
    public long Id { get; set; }

    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }

    [Column("user_email")]
    public string? UserEmail { get; set; }
}