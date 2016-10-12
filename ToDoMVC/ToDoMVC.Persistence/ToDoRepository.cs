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
    public class ToDoRepository : IRepository<ToDo>
    {
        private readonly DbSet<ToDo> _dbSet;

        public ToDoRepository(DbSet<ToDo> datacontext)
        {
            _dbSet = datacontext;
        }

        public void Delete(ToDo entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<ToDo> GetAll()
        {
            return _dbSet;
        }

        public ToDo GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(ToDo entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<ToDo> SearchFor(Expression<Func<ToDo, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Save()
        {
            
        }
    }
}
