using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Application.Interface;
using Transport.Infrastructure.Data;

namespace Transport.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TransportDbContext _db;
        internal DbSet<T> dbSet;


        public Repository(TransportDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            try
            {
                await _db.AddAsync(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true, string? includeProperties = null)
        {
            try
            {
                IQueryable<T> query = dbSet;
                if (!tracked)
                {
                    query = query.AsNoTracking();
                }
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                //_cacheService.SetAsync<T>("product", query.FirstOrDefaultAsync().Result);
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (pageSize > 0)
                {
                    if (pageSize > 100)
                    {
                        pageSize = 100;
                    }
                    //skip0.take(5)
                    //page number- 2     || page size -5
                    //skip(5*(1)) take(5)
                    query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
                }
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task RemoveAsync(T entity)
        {
            try
            {
                dbSet.Remove(entity);
                await SaveAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }


    }
}
