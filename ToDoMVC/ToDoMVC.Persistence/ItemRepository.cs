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
    class ItemRepository : IRepository<Item>
    {
        private readonly DbSet<Item> _dbSet;

        public ItemRepository(DbSet<Item> datacontext)
        {
            _dbSet = datacontext;
        }

        public void Delete(Item entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public Item GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Item entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Item> SearchFor(Expression<Func<Item, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
