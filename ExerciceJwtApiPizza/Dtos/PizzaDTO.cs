using ExerciceJwtApiPizza.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExerciceJwtApiPizza.Dtos
{
    public class PizzaDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Le nom de la pizza est requis.")]
        public string Name { get; set; }

        [Column("Description")]
        [Required(ErrorMessage = "La description de la pizza est requise.")]
        public string Description { get; set; }

        [Column("Price")]
        [Required(ErrorMessage = "Le prix de la pizza est requis.")]
        public decimal Price { get; set; }

        [Column("Image")]
        [Required(ErrorMessage = "L'URL de l'image de la pizza est requise.")]
        public string ImageUrl { get; set; }

        [Column("Status")]
        [Required(ErrorMessage = "Le type de pizza est requis.")]
        public PizzaStatus Variety { get; set; }

        public List<Ingredient> Ingredients { get; set; } 

        public enum PizzaStatus
        {
            Regular,
            Vegetarian,
            Spicy
        }
    }
}
