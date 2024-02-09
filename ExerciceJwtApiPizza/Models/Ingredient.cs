using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciceJwtApiPizza.Models
{
    public class Ingredient
    {
        [Column("Id")]
        public int Id { get; set; } 

        [Column("Name")]
        public string Name { get; set; } 

        [Column("Description")]
        public string Description { get; set; } 
    }
}
