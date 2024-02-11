using ExerciceJwtApiPizza.Validator;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExerciceJwtApiPizza.Dtos
{
    public class UserDTO
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("firstname")]
        [Required]
        public string? FirstName { get; set; }
        [Column("lastname")]
        [Required]
        public string? LastName { get; set; }
        [Column("is_admin")]
        [Required]
        public bool IsAdmin { get; set; } = false;
        [RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Invalid email address")]
        [Column("email")]
        [Required]
        public String Email { get; set; }
        [PasswordValidator]
        [Column("password")]
        [Required]
        public String Password { get; set; }
    }
}