using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T First(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);
        void Delete(Guid id);

        T Update(T entity);

        void SaveChanges();
    }
}
