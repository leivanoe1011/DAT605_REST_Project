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
    class ToDoRepository : IRepository<ToDo>
    {
        private readonly DbSet<ToDo> _dbSet;

        public ToDoRepository(DbSet<ToDo> datacontext)
        {
            _dbSet = datacontext;
        }

        public void Delete(ToDo entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ToDo> GetAll()
        {
            throw new NotImplementedException();
        }

        public ToDo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ToDo entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ToDo> SearchFor(Expression<Func<ToDo, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
