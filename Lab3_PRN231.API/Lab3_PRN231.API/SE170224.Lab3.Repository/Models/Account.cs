using System.ComponentModel.DataAnnotations;

namespace Lab3_PRN231.Repository.Models;

public partial class Account
{
    [Key]
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public RoleEnum Role { get; set; }
}
