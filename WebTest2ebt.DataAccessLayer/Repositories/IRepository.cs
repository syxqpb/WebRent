namespace WebTest2ebt.DataAccessLayer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using WebTest2ebt.DataAccessLayer.Models;
    using WebTest2ebt.DataAccessLayer.Models.Identity;

    /// <summary>
    /// Interface of generic repository for data base.
    /// </summary>
    /// <typeparam name="TEntity">Entity class.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Method for adding item in table.
        /// </summary>
        /// <param name="item">Adding item.</param>
        /// <returns>Void return.</returns>
        Task Create(TEntity item);

        /// <summary>
        /// Add models.
        /// </summary>
        /// <param name="entities">Adding models.</param>
        /// <returns>Task result.</returns>
        Task CreateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Method for getting all items from table.
        /// </summary>
        /// <returns>All items.</returns>
        Task<IEnumerable<TEntity>> Get();

        /// <summary>
        /// Method for getting items from table with some filter.
        /// </summary>
        /// <param name="predicate">Search filter.</param>
        /// <returns>Result items.</returns>
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Metohd for removing an item from table.
        /// </summary>
        /// <param name="item">Removing item.</param>
        /// <returns>Void return.</returns>
        Task Remove(TEntity item);

        /// <summary>
        /// dsd.
        /// </summary>
        /// <param name="predicate">sdsd.</param>
        /// <returns>s.</returns>
        Task<TEntity> FindItem(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Remove models.
        /// </summary>
        /// <param name="entities">Removing entities.</param>
        /// <returns>Task result.</returns>
        Task RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Method for updating item.
        /// </summary>
        /// <param name="item">Updating item.</param>
        /// <returns>Void return.</returns>
        Task Update(TEntity item);

        /// <summary>
        /// Update models.
        /// </summary>
        /// <param name="items">Updating models.</param>
        /// <returns>Task result.</returns>
        Task UpdateRange(IEnumerable<TEntity> items);

        Task<IEnumerable<TEntity>> GetForPage(int pageNumber, int pageSize);
       

        /// <summary>
        /// Get ads with predicate for page.
        /// </summary>
        /// <param name="predicate">Predicate object.</param>
        /// <param name="pageNumber">Current page number.</param>
        /// <param name="pageSize">Ads count in page.</param>
        /// <returns>Ads list.</returns>
        Task<IEnumerable<TEntity>> GetForPage(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize);
       


        /// <summary>
        /// Get rental ads count.
        /// </summary>
        /// <returns>Ads count.</returns>
        Task<int> GetCount();


        /// <summary>
        /// Get rental ads count with predicate.
        /// </summary>
        /// <param name="predicate">Predicate object.</param>
        /// <returns>Ads count.</returns>
        Task<int> GetCount(Expression<Func<TEntity, bool>> predicate);
        Task<IdentityBuyer> GetUser(string id);
        Task<CartDto> GetCart(int id);
        Task Save();


    }
}
