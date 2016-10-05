using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;

namespace ToDoMVC.Business
{
    class ToDoDataAdapter : IDataAdapter<ToDoDto>
    {
        private readonly IRepository<ToDo> _repository;

        public ToDoDataAdapter(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public void Delete(ToDoDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDoDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ToDoDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ToDoDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDoDto> SearchFor()
        {
            throw new NotImplementedException();
        }
    }
}
