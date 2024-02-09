using ExerciceJwtApiPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciceJwtApiPizza.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Margherita", Description = "Classic Italian pizza ", Price = 8.99m, Image = "margherita.jpg", Status = PizzaStatus.Regular },
                new Pizza { Id = 2, Name = "Vegetarian", Description = "Pizza with fresh vegetables.", Price = 9.99m, Image = "vegetarian.jpg", Status = PizzaStatus.Vegetarian },
                new Pizza { Id = 3, Name = "Spicy Pepperoni", Description = "Spicy pizza with pepperoni.", Price = 10.99m, Image = "spicy_pepperoni.jpg", Status = PizzaStatus.Spicy }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", PhoneNumber = "023456789", Address = "123 Pizza St", IsAdmin = false },
                new User { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", PhoneNumber = "087654321", Address = "456 Okay St", IsAdmin = true }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato Sauce", Description = "Traditional tomato sauce." },
                new Ingredient { Id = 2, Name = "Mozzarella Cheese", Description = "Fresh mozzarella." },
                new Ingredient { Id = 3, Name = "Basil", Description = "Fresh basil." }
            );
        }
    }
}

