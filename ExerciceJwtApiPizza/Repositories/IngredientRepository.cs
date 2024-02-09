using ExerciceJwtApiPizza.Data;
using ExerciceJwtApiPizza.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExerciceJwtApiPizza.Repositories
{


    public interface IngredientRepository : IRepository<Ingredient>
    {
        private readonly AppDbContext _db;

        public IngredientRepository(AppDbContext db)
        {
            _db = db;
        }



        public async Task<Ingredient?> Add(Ingredient ingredient)
        {
            var addEntry = await _db.Ingredients.AddAsync(ingredient);
            await _db.SaveChangesAsync();

            if (addEntry.Entity.Id > 0)
                return addEntry.Entity;

            return null;
        }



        public async Task<Ingredient?> Get(int id)
        {
            return await _db.Ingredients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Ingredient?> Get(Expression<Func<Ingredient, bool>> predicate)
        {
            return await _db.Ingredients.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            return _db.Ingredients;

        }

        public async Task<IEnumerable<Ingredient>> GetAll(Expression<Func<Ingredient, bool>> predicate)
        {
            return _db.Ingredients.Where(predicate);

        }



        public async Task<Ingredient?> Update(Ingredient ingredient)
        {
            var ingredientFromDb = await Get(ingredient.Id);

            if (ingredientFromDb == null)
                return null;

            if (ingredientFromDb.Id != ingredient.Id)
                ingredientFromDb.Id = ingredient.Id;
            if (ingredientFromDb.Name != ingredient.Name)
                ingredientFromDb.Name = ingredient.Name;
            if (ingredientFromDb.Description != ingredient.Description)
                ingredientFromDb.Description = ingredient.Description;


            if (await _db.SaveChangesAsync() == 0)
                return null;

            return ingredientFromDb;
        }



        public async Task<bool> Delete(int id)
        {
            var contactFromDb = await Get(id);

            if (contactFromDb == null)
                return false;

            _db.Ingredients.Remove(contactFromDb);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}