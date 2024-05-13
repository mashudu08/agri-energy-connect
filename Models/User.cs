using Agri_Energy_Connect.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Agri_Energy_Connect.Models;

[Table("User")]
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public Role Role { get; set; }
}