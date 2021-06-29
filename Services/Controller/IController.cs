using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services
{
    public interface IController<T> where T : class
    {
        IEnumerable<T> LoadData(Expression<Func<T, bool>> expression = null);
        T GetFirstOrDefatult(Expression<Func<T, bool>> expression = null);
        bool Save(T obj);
        bool Update(T obj);
        bool Delete(int id);
    }
}
