using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Models;

namespace DataAccess
{
    public interface IRepository<T> where T : BaseDomain
    {
        T Find(int id);
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            bool isTracking = false
        );

        T FirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null,
            bool isTracking = false
        );

        void Add(T entity);
        void Remove(int id);
        void RemoveRange(IEnumerable<T> entity);
        void Save();
    }
}
