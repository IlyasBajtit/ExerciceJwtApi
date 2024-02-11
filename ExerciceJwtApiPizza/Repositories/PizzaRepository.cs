using ExerciceJwtApiPizza.Data;
using ExerciceJwtApiPizza.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExerciceJwtApiPizza.Repositories
{


    public class PizzaRepository : IRepository<Pizza>
    {
        private readonly AppDbContext _db;

        public PizzaRepository(AppDbContext db)
        {
            _db = db;
        }



        public async Task<Pizza?> Add(Pizza pizza)
        {
            var addEntry = await _db.Pizzas.AddAsync(pizza);
            await _db.SaveChangesAsync();

            if (addEntry.Entity.Id > 0)
                return addEntry.Entity;

            return null;
        }



        public async Task<Pizza?> Get(int id)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Pizza?> Get(Expression<Func<Pizza, bool>> predicate)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            return _db.Pizzas;

        }

        public async Task<IEnumerable<Pizza>> GetAll(Expression<Func<Pizza, bool>> predicate)
        {
            return _db.Pizzas.Where(predicate);

        }



        public async Task<Pizza?> Update(Pizza pizza)
        {
            var pizzaFromDb = await Get(pizza.Id);

            if (pizzaFromDb == null)
                return null;

            if (pizzaFromDb.Id != pizzaFromDb.Id)
                pizzaFromDb.Id = pizzaFromDb.Id;
            if (pizzaFromDb.Name != pizzaFromDb.Name)
                pizzaFromDb.Name = pizzaFromDb.Name;
            if (pizzaFromDb.Description != pizzaFromDb.Description)
                pizzaFromDb.Description = pizzaFromDb.Description;


            if (await _db.SaveChangesAsync() == 0)
                return null;

            return pizzaFromDb;
        }



        public async Task<bool> Delete(int id)
        {
            var pizzaFromDb = await Get(id);

            if (pizzaFromDb == null)
                return false;

            _db.Pizzas.Remove(pizzaFromDb);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
