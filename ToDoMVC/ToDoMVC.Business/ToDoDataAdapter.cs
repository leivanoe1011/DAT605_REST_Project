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
        private readonly IMapper _objectToDtoMapper;
        private readonly IMapper _dtoToObjectMapper;

        public ToDoDataAdapter(IRepository<ToDo> repository, IMapper objectToDtoMapper, IMapper dtoToObjectMapper)
        {
            _repository = repository;
            _objectToDtoMapper = objectToDtoMapper;
            _dtoToObjectMapper = dtoToObjectMapper;
        }

        public void Delete(DataToDo entity)
        {
            var allToDos = _repository.GetAll();

            var todoToDelete = allToDos.FirstOrDefault(x => x.Name.Equals(entity.Name));
            
            _repository.Delete(todoToDelete);
        }

        public IEnumerable<DataToDo> GetAll()
        {
            var allToDos = _repository.GetAll();
            var dataToDos = new List<DataToDo>();

            foreach (var i in allToDos)
            {
                dataToDos.Add(_objectToDtoMapper.Map<ToDo, DataToDo>(i));
            }

            return dataToDos;
        }

        public DataToDo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DataToDo entity)
        {
            _repository.Insert(_dtoToObjectMapper.Map<DataToDo, ToDo>(entity));
        }

        public IEnumerable<DataToDo> SearchFor()
        {
            throw new NotImplementedException();
        }
    }
}
