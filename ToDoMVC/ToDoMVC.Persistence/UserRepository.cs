using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;

namespace ToDoMVC.Persistence
{
    public class UserRepository : IRepository<User>
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(DbSet<User> datacontext)
        {
            _dbSet = datacontext;
        }

        public void Insert(User entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(User entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<User> SearchFor(Expression<Func<User, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<User> GetAll()
        {
            return _dbSet;
        }

        public User GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
