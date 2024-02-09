using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExerciceJwtApiPizza.Models
{
    public class User
    {

        [Column("Id")]
        public int Id { get; set; } 

        [Column("FirstName")]
        public string FirstName { get; set; } 

        [Column("LastName")]
        public string LastName { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Invalid email address")]
        [Required]
        public String Email { get; set; }

        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; } 

        [Column("Address")]
        public string Address { get; set; }

        public bool IsAdmin { get; set; } = false;


    }
}
