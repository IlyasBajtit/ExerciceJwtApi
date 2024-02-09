using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciceJwtApiPizza.Models
{
    public class Pizza
    {
        [Column("Id")]
        public int Id { get; set; } 

        [Column("Name")]
        public string Name { get; set; } 

        [Column("Description")]
        public string Description { get; set; } 

        [Column("Price")]
        public decimal Price { get; set; } 

        [Column("Image")]
        public string Image { get; set; } 

        [Column("Status")]
        public PizzaStatus Status { get; set; }  
    }
}
public enum PizzaStatus
{
    Regular,
    Vegetarian,
    Spicy
}