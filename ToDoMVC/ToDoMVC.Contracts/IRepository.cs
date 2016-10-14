using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace ToDoMVC.Contracts
{

    /// <summary>
    /// Responsibilities: 
    /// Interface for CRUD operation for repository classes.
    /// 
    /// Implemented By:
    /// Persistence Repositories
    /// 
    /// Used By:
    /// Business Adapters
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
        void Save();
    }
}
