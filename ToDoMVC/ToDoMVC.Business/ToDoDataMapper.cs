using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;

namespace ToDoMVC.Business
{
    public class ToDoDataMapper : IDataMapper<DataToDo, ToDo>
    {
        private readonly IDataMapper<DataItem, Item> _iDataMapper;

        public ToDoDataMapper(IDataMapper<DataItem, Item> iDataMapper)
        {
            _iDataMapper = iDataMapper;
        }

        public IList<DataToDo> MapToDto(IEnumerable<ToDo> obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataToDo> MapToDto(IQueryable<ToDo> obj)
        {
            var todo = new List<DataToDo>();

            foreach (var i in obj)
            {
                todo.Add(new DataToDo()
                {
                    Name = i.Name,
                    //Items = _iDataMapper.MapToDto(i.Items)
                });
            }

            return todo;
        }
    }
}
