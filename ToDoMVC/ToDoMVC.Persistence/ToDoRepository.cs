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
        private readonly ToDoMVCEntities _entities;

        public ToDoRepository(ToDoMVCEntities entities)
        {
            _entities = entities;
            _dbSet = _entities.ToDoes;
        }

        public void Delete(ToDo entity)
        {
            _dbSet.Remove(entity);
            Save();
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
            Save();
        }

        public IQueryable<ToDo> SearchFor(Expression<Func<ToDo, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
