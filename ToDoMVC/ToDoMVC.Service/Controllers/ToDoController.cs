using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;

namespace ToDoMVC.Service.Controllers
{
    public class ToDoController : ApiController
    {
        private IDataAdapter<ToDoDto> _todoDataAdapter;

        public ToDoController(IDataAdapter<ToDoDto> todoDataAdapter)
        {
            _todoDataAdapter = todoDataAdapter;
        }

        public ToDoController()
        {
            //defautl for testing only
        }

        public IEnumerable<ToDoDto> Get()
        {
            return _todoDataAdapter.GetAll();
        }

        public ToDoDto Get(int id)
        {
            return _todoDataAdapter.GetById(id);
        }

        public void Post(ToDoDto todo)
        {
            _todoDataAdapter.Insert(todo);
        }

        public void Delete(ToDoDto todo)
        {
            _todoDataAdapter.Delete(todo);
        }
    }
}
