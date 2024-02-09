using System.Linq.Expressions;

namespace ExerciceJwtApiPizza.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        Task<TEntity?> Add(TEntity entity);


        Task<TEntity?> Get(int id);
        Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);


        Task<TEntity?> Update(TEntity entity);


        Task<bool> Delete(int id);

    }
}
