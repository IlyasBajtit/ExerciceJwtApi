using ExerciceJwtApiPizza.Validator;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExerciceJwtApiPizza.Dtos
{
    public class UserDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("FirstName")]
        [Required(ErrorMessage = "Le prénom est requis.")]
        public string? FirstName { get; set; }

        [Column("LastName")]
        [Required(ErrorMessage = "Le nom de famille est requis.")]
        public string? LastName { get; set; }

        [Column("Email")]
        [Required(ErrorMessage = "L'adresse email est requise.")]
        [RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Adresse email invalide")]
        public string Email { get; set; }

        [Column("PhoneNumber")]
        [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
        public string PhoneNumber { get; set; }

        [Column("Address")]
        [Required(ErrorMessage = "L'adresse est requise.")]
        public string Address { get; set; }

        [Column("IsAdmin")]
        [Required(ErrorMessage = "La spécification 'isAdmin' est requise.")]
        public bool IsAdmin { get; set; } = false;

        public string Password { get; set; }
    }
}