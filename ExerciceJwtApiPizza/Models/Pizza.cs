using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciceJwtApiPizza.Models
{
    public class Pizza
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }

        [Column("Description")]
        [Required]
        public string Description { get; set; }

        [Column("Price")]
        [Required]
        public decimal Price { get; set; }

        [Column("Image")]
        [Required]
        public string Image { get; set; }

        [Column("Status")]
        [Required]
        public PizzaStatus Status { get; set; }
    }

    public enum PizzaStatus
    {
        Regular,
        Vegetarian,
        Spicy
    }
}