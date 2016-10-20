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

     /// <summary>
     /// Responsibilities:
     /// The controller that will be reference by the WebApiConfig cs.
     /// api/{Controller}/{Action}
     /// </summary>

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

        /// HttpGet will be the action that will be referenced by the API call
        /// Then the method below will be called.
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


        /// HttpGet will be the action that will be referenced by the API call
        /// Then the method below will be called.
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


        /// HttpPost will be the action that will be referenced by the API call
        /// Then the method below will be called.
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


        /// HttpDelete will be the action that will be referenced by the API call
        /// Then the method below will be called.
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


        /// HttpPut will be the action that will be referenced by the API call
        /// Then the method below will be called.
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
