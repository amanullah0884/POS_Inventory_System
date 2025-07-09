using Microsoft.EntityFrameworkCore;
using POS_Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Base
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly InventoryContext _context;
        private DbSet<T> _dbset;


        public GenericRepo(InventoryContext context)
        {
            _context = context;
        //    _dbset = _context.Set<T>();

        }
        public async Task Add(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public void Add(List<T> entity)
        {
            _dbset.AddRangeAsync(entity);
        }

        public void Delete(int id)
        {
            //_dbset.Remove
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void DeletebyID(Expression<Func<T, bool>> predicate)
        {
            var item = _dbset.Where(predicate).FirstOrDefault();
            _dbset.Remove(item);
        }

        public void DeleteRange(IEnumerable<T> entitylist)
        {
            _dbset.RemoveRange(entitylist);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate, string? includeProperties)
        {
            IQueryable<T> query = _dbset;
            try
            {
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }
                if (includeProperties != null)
                {
                    foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(item);
                    }
                }
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).FirstOrDefault();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
    }
}
