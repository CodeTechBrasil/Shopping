using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Models;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseDomain,new()
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public T Find(int id) => dbSet.Find(id);

        public T FirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null, bool isTracking = false)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
                foreach (var includeProp in includeProperties.Split(new char[] {','},
                    StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);

            if (!isTracking)
                query = query.AsNoTracking();

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, bool isTracking = false)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
                foreach (var includeProp in includeProperties.Split(new char[] {','},
                    StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);

            if (orderBy != null)
                query = orderBy(query);

            if (!isTracking)
                query = query.AsNoTracking();

            return query.ToList();
        }

        public void Add(T entity) => dbSet.Add(entity);
        public void Remove(int id) => dbSet.Remove(new T{Id = id});
        public void RemoveRange(IEnumerable<T> entity) => dbSet.RemoveRange(entity);
        public void Save() => _db.SaveChanges();
    }
}
