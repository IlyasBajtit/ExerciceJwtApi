using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExerciceJwtApiPizza.Dtos
{
    public class IngredientDTO
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("description")]
        [Required]
        public string Description { get; set; }

    }
}