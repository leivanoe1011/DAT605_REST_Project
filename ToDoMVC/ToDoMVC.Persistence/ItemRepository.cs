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
    public class ItemRepository : IRepository<Item>
    {
        private readonly DbSet<Item> _dbSet;
        private readonly ToDoMVCEntities _entites;

        public ItemRepository(ToDoMVCEntities entities)
        {
            _entites = entities;
            _dbSet = _entites.Items;
        }

        public void Delete(Item entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public IQueryable<Item> GetAll()
        {
            return _dbSet;
        }

        public Item GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(Item entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public IQueryable<Item> SearchFor(Expression<Func<Item, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Save()
        {
            _entites.SaveChanges();
        }
    }
}
