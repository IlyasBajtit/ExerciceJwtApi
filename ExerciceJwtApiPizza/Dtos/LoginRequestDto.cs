using ExerciceJwtApiPizza.Validator;
using System.ComponentModel.DataAnnotations;

namespace ExerciceJwtApiPizza.Dtos
{
    public class LoginRequestDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        [PasswordValidator]
        public string Password { get; set; }


    }
}