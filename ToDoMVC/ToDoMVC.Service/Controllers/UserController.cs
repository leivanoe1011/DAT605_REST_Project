using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoMVC.Contracts;

using ToDoMVC.Persistence;
using ToDoMVC.Domain;
using ToDoMVC.Infrastructure;

namespace ToDoMVC.Service.Controllers
{

    /// <summary>
    /// Reponsibility:
    /// Web API controllers for Users.
    /// 
    /// Interactions:
    /// ToDoMVC.Business Adapters
    /// ToDoMVC.Infrastructure Factories
    /// </summary>

    public class UserController : ApiController
    {
        private readonly IDataAdapter<DataUser> _userDataAdapter;
        private readonly UserFactory _factory;

        public UserController(IDataAdapter<DataUser> userDataAdapter)
        {
            _userDataAdapter = userDataAdapter;
        }

        public UserController()
        {
            _factory = new UserFactory();
            _userDataAdapter = _factory.CreateUserAdapter();
        }

        /// <summary>
        /// Return all DataUsers from repository.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DataUser> Get()
        {
            return _userDataAdapter.GetAll();
        }

        /// <summary>
        /// Return single DataUser via identification number.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public DataUser Get(int id)
        {
            return _userDataAdapter.GetById(id);
        }

        /// <summary>
        /// Create new DataUser via string param, add to database via business adapter.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post(string name, int id)
        {
            var newUser = new DataUser()
            {
                Name = name,
                Id = id
            }; 

            _userDataAdapter.Insert(newUser);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        /// <summary>
        /// Create new DataUser via string param, delete from database via business adapter.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var userToDelete = new DataUser()
            {
                Id = id
            };

            _userDataAdapter.Delete(userToDelete);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, string name)
        {
            var userToPut = new DataUser()
            {
                Name = name,
                Id = id
            };

            _userDataAdapter.Update(userToPut);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
