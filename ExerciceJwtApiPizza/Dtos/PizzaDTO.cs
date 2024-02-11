using ExerciceJwtApiPizza.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExerciceJwtApiPizza.Dtos
{
    public class PizzaDTO
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("description")]
        [Required]
        public string Description { get; set; }
        [Column("price")]
        [Required]
        public decimal Price { get; set; }
        [Column("image_url")]
        [Required]
        public string ImageUrl { get; set; }
        [Column("pizza_type")]
        [Required]
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