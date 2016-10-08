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
    public class ToDoDataMapper : IDataMapper<ToDo, DataToDo>
    {
        private readonly IDataMapper<Item, DataItem> _iDataMapper;

        public ToDoDataMapper(IDataMapper<Item, DataItem> iDataMapper)
        {
            _iDataMapper = iDataMapper;
        }

        public ToDo MapToDto(DataToDo obj)
        {
            var todo = new ToDo {Name = obj.Name};

            foreach (var i in obj.Items)
            {
                todo.Items.Add(_iDataMapper.MapToDto(i));
            }

            return todo;
        }

        public DataToDo MapToObject(ToDo obj)
        {
            var todo = new DataToDo {Name = obj.Name};

            foreach (var i in obj.Items)
            {
                todo.Items.Add(_iDataMapper.MapToObject(i));
            }

            return todo;
        }
    }
}
