using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;

namespace ToDoMVC.Persistence
{

    /// <summary>
    /// Responsibility:
    /// CRUD into database. Serve up DBSet objects to business logic.
    /// 
    /// Interactions:
    /// ToDoMVC.Service Adapters
    /// ToDoMVC.Infrastructure Factories
    /// </summary>

    public class UserRepository : IRepository<User>, IDisposable
    {
        private readonly ToDoMVCEntities _entities;
        private readonly DbSet<User> _dbSet;

        public UserRepository(ToDoMVCEntities entities)
        {
            _entities = entities;
            _dbSet = _entities.Users;
        }

        /// <summary>
        /// Insert entity into database, save database. 
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(User entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        /// <summary>
        /// Remove entity from database, save database.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(User entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        /// <summary>
        /// Search for and return eitty via linq expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<User> SearchFor(Expression<Func<User, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        /// <summary>
        /// Return all Users in database.
        /// </summary>
        /// <returns></returns>
        public IQueryable<User> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        /// Return single User via identification number.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Save all database changes.
        /// </summary>
        public void Save()
        {
            _entities.SaveChanges();
        }

        /// <summary>
        /// Dispose of ToDoMVCEntities. 
        /// </summary>
        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}
