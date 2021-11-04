// <copyright file="RentalOfPropertyRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebTest2ebt.DataAccessLayer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using WebTest2ebt.DataAccessLayer.Context;
    using WebTest2ebt.DataAccessLayer.Models;
    using WebTest2ebt.DataAccessLayer.Models.Identity;


    /// <summary>
    /// Generic repository for data base.
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public class PhotoRentRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Db set.
        /// </summary>
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Db context.
        /// </summary>
        private PhotoRentContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoRentRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">Db context.</param>
        public PhotoRentRepository(PhotoRentContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Method for getting all items from table.
        /// </summary>
        /// <returns>All items.</returns>
        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbSet.AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get using predicate.
        /// </summary>
        /// <param name="predicate">Predicate object.</param>
        /// <returns>Models list.</returns>
        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }

        /// <summary>
        /// Add model.
        /// </summary>
        /// <param name="item">Adding model.</param>
        /// <returns>Task result.</returns>
        public async Task Create(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Add models.
        /// </summary>
        /// <param name="entities">Adding models.</param>
        /// <returns>Task result.</returns>
        public async Task CreateRange(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update model.
        /// </summary>
        /// <param name="item">Updating model.</param>
        /// <returns>Task result.</returns>
        public async Task Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update models.
        /// </summary>
        /// <param name="items">Updating models.</param>
        /// <returns>Task result.</returns>
        public async Task UpdateRange(IEnumerable<TEntity> items)
        {
            _context.UpdateRange(items);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove model.
        /// </summary>
        /// <param name="item">Removing model.</param>
        /// <returns>Task result.</returns>
        public async Task Remove(TEntity item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove models.
        /// </summary>
        /// <param name="entities">Removing entities.</param>
        /// <returns>Task result.</returns>
        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get ads for page.
        /// </summary>
        /// <param name="pageNumber">Current page number.</param>
        /// <param name="pageSize">Ads count in page.</param>
        /// <returns>Ads list.</returns>
        public async Task<IEnumerable<TEntity>> GetForPage(int pageNumber, int pageSize)
        {
            const int DefaultIndex = 1;

            return await _dbSet.AsNoTracking()
                .Skip((pageNumber - DefaultIndex) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Get ads with predicate for page.
        /// </summary>
        /// <param name="predicate">Predicate object.</param>
        /// <param name="pageNumber">Current page number.</param>
        /// <param name="pageSize">Ads count in page.</param>
        /// <returns>Ads list.</returns>
        public async Task<IEnumerable<TEntity>> GetForPage(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize)
        {
            const int DefaultIndex = 1;

            return await _dbSet.AsNoTracking()
                .Where(predicate)
                .Skip((pageNumber - DefaultIndex) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
       

        /// <summary>
        /// Get rental ads count.
        /// </summary>
        /// <returns>Ads count.</returns>
        public async Task<int> GetCount()
        {
            return await _dbSet.AsNoTracking().CountAsync();
        }

        /// <summary>
        /// Get rental ads count with predicate.
        /// </summary>
        /// <param name="predicate">Predicate object.</param>
        /// <returns>Ads count.</returns>
        public async Task<int> GetCount(Expression<Func<TEntity, bool>> predicate)
        {
             return await _dbSet.AsNoTracking()
            .Where(predicate)
            .CountAsync();
        }

        public async Task<IdentityBuyer> GetUser(string id)
        {
            var user = await _context.Set<IdentityBuyer>().Include("Carts").FirstOrDefaultAsync(item => item.Id.Equals(id));
            return user;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }


        //Метод дичччч
        public void SaveProduct(EquipmentDto equipment)
        {
            if (equipment.Id == 0)
            {
                _context.Equipments.Add(equipment);
            }
            else
            {
                EquipmentDto dЬEntry = _context.Equipments
                .FirstOrDefault(p => p.Id == equipment.Id);
                if (dЬEntry != null)
                {
                    dЬEntry.Name = equipment.Name;
                    dЬEntry.Manufacturer = equipment.Manufacturer;
                    dЬEntry.Model = equipment.Model;
                    dЬEntry.ReceiptDate = equipment.ReceiptDate;
                    dЬEntry.WriteOffDate = equipment.WriteOffDate;
                    dЬEntry.Сondition = equipment.Сondition;
                    dЬEntry.Сost = equipment.Сost;
                    _context.SaveChanges();
                }
            }
        }
        public async Task<CartDto> GetCart(int id)
        {
            var user = await _context.Set<CartDto>().Include("Equipments").FirstOrDefaultAsync(item => item.Id ==(id));
            return user;
        }

        public async Task<TEntity> FindItem(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking()
               .Where(predicate)
               .FirstOrDefaultAsync();
        }

        

    }
}
