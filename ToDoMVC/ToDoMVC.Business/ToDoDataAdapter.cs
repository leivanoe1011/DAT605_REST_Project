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
        private readonly IUnitOfWork _uow;
        private readonly IMapper _objectToDtoMapper;
        private readonly IMapper _dtoToObjectMapper;

        public ToDoDataAdapter(IUnitOfWork uow, IMapper objectToDtoMapper, IMapper dtoToObjectMapper)
        {
            _uow = uow;
            _objectToDtoMapper = objectToDtoMapper;
            _dtoToObjectMapper = dtoToObjectMapper;
        }

        public void Delete(DataToDo entity)
        {
            var allToDos = _uow.ToDoRepository.GetAll();

            var todoToDelete = allToDos.FirstOrDefault(x => x.Id.Equals(entity.Id));

            _uow.ToDoRepository.Delete(todoToDelete);
        }

        public IEnumerable<DataToDo> GetAll()
        {
            var allToDos = _uow.ToDoRepository.GetAll();
            var dataToDos = new List<DataToDo>();

            foreach (var i in allToDos)
            {
                dataToDos.Add(_objectToDtoMapper.Map<ToDo, DataToDo>(i));
            }

            return dataToDos;
        }

        public DataToDo GetById(int id)
        {
            var allToDos = _uow.ToDoRepository.GetAll();

            return _objectToDtoMapper.Map<ToDo, DataToDo>(allToDos.FirstOrDefault(x => x.Id.Equals(id)));
        }

        public void Update(DataToDo entity)
        {
            var allToDos = _uow.ToDoRepository.GetAll();

            var todoToUpdate = allToDos.FirstOrDefault(x => x.Id.Equals(entity.Id));

            todoToUpdate.Name = entity.Name;

            _uow.ToDoRepository.Save();
        }

        public void Insert(DataToDo entity)
        {
            _uow.ToDoRepository.Insert(_dtoToObjectMapper.Map<DataToDo, ToDo>(entity));
        }

    }
}
