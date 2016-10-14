using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;

namespace ToDoMVC.Business
{
    public class ToDoDataAdapter : IDataAdapter<DataToDo>
    {
        private readonly IRepository<ToDo> _repository;
        private readonly IMapper _mapper;

        public ToDoDataAdapter(IRepository<ToDo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Delete(DataToDo entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataToDo> GetAll()
        {
            var allToDos = _repository.GetAll();
            var dataToDos = new List<DataToDo>();

            foreach (var i in allToDos)
            {
                dataToDos.Add(_mapper.Map<ToDo, DataToDo>(i));
            }

            return dataToDos;
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
