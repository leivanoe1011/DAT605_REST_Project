using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Infrastructure;
using ToDoMVC.Service.Auth;

namespace ToDoMVC.Service.Controllers
{
    [BasicAuth]
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

        [HttpGet]
        public IEnumerable<DataToDo> Get()
        {
            try
            {
                return _todoDataAdapter.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public DataToDo Get(int id)
        {
            try
            {
                return _todoDataAdapter.GetById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [HttpPost]
        public HttpResponseMessage Post(string name, int userid, int id)
        {
            try
            {
                var newToDo = new DataToDo()
                {
                    Name = name,
                    UserId = userid,
                    Id = id
                };

                _todoDataAdapter.Insert(newToDo);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var todoToDelete = new DataToDo()
                {
                    Id = id
                };

                _todoDataAdapter.Delete(todoToDelete);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, string name)
        {
            try
            {
                var ToDoToPut = new DataToDo()
                {
                    Id = id,
                    Name = name
                };

                _todoDataAdapter.Update(ToDoToPut);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
