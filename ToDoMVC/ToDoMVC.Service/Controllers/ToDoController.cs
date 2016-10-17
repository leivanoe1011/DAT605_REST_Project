using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Infrastructure;

namespace ToDoMVC.Service.Controllers
{
    public class ToDoController : ApiController
    {
        private readonly IDataAdapter<DataToDo> _todoDataAdapter;
        private readonly ToDoFactory _factory;

        public ToDoController(IDataAdapter<DataToDo> todoDataAdapter)
        {
            _todoDataAdapter = todoDataAdapter;
        }

        public ToDoController()
        {
            _factory = new ToDoFactory();
            _todoDataAdapter = _factory.CreateToDoAdapter();
        }

        public IEnumerable<DataToDo> Get()
        {
            return _todoDataAdapter.GetAll();
        }

        public DataToDo Get(int id)
        {
            return _todoDataAdapter.GetById(id);
        }

        [HttpPost]
        public HttpResponseMessage Post(string name, string user)
        {
            var newToDo = new DataToDo()
            {
                Name = name,
                UserName = user
            };

            _todoDataAdapter.Insert(newToDo);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Delete(string name)
        {
            var todoToDelete = new DataToDo()
            {
                Name = name
            };

            _todoDataAdapter.Delete(todoToDelete);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
