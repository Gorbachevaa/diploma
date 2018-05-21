using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets Entity.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity with the id.</returns>
        TEntity Get(int id);
        /// <summary>
        /// Gets all objects.
        /// </summary>
        /// <returns>Group of objects.</returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Find object by some query.
        /// </summary>
        /// <param name="predicate">An expression of Func, means using lambda-expression to filter objects.</param>
        /// <returns>Found objects.</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adds one object. 
        /// </summary>
        /// <param name="entity">Added object</param>
        void Add(TEntity entity);
        /// <summary>
        /// Adds list of objects.
        /// </summary>
        /// <param name="entities">List of objects to add.</param>
        void AddRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Removes objects.
        /// </summary>
        /// <param name="entity">Removed objects</param>
        void Remove(TEntity entity);
        /// <summary>
        /// Removes list of objects.
        /// </summary>
        /// <param name="entites">List of objects to remove</param>
        void RemoveRange(IEnumerable<TEntity> entites);

    }
}
