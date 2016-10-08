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
    class ToDoDataAdapter : IDataAdapter<DataToDo>
    {
        private readonly IRepository<ToDo> _repository;

        public ToDoDataAdapter(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public void Delete(DataToDo entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataToDo> GetAll()
        {
            throw new NotImplementedException();
        }

        public DataToDo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DataToDo entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataToDo> SearchFor()
        {
            throw new NotImplementedException();
        }
    }
}
