using ExerciceJwtApiPizza.Data;
using ExerciceJwtApiPizza.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExerciceJwtApiPizza.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }


        public async Task<User?> Add(User user)
        {
            var addEntry = await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            if (addEntry.Entity.Id > 0)
                return addEntry.Entity;

            return null;
        }



        public async Task<User?> Get(int id)
        {

            return await _db.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<User?> Get(Expression<Func<User, bool>> predicate)
        {
            return await _db.Users.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return _db.Users;
            ;
        }

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> predicate)
        {
            return _db.Users.Where(predicate);

        }



        public async Task<User?> Update(User user)
        {
            var userFromDb = await Get(user.Id);

            if (userFromDb == null)
                return null;

            if (userFromDb.FirstName != user.FirstName)
                userFromDb.FirstName = user.FirstName;
            if (userFromDb.LastName != user.LastName)
                userFromDb.LastName = user.LastName;
            if (userFromDb.Email != user.Email)
                userFromDb.Email = user.Email;
            if (userFromDb.PhoneNumber != user.PhoneNumber)
                userFromDb.PhoneNumber = user.PhoneNumber;
            if (userFromDb.Address != user.Address)
                userFromDb.Address = user.Address;
            if (userFromDb.IsAdmin != user.IsAdmin)
                userFromDb.IsAdmin = user.IsAdmin;

            if (await _db.SaveChangesAsync() == 0)
                return null;

            return userFromDb;
        }



        public async Task<bool> Delete(int id)
        {
            var userFromDb = await Get(id);

            if (userFromDb == null)
                return false;

            _db.Users.Remove(userFromDb);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}