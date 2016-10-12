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

        [HttpGet]
        public IEnumerable<DataUser> Get()
        {
            return _userDataAdapter.GetAll();
        }

        [HttpGet]
        public DataUser Get(int id)
        {
            return _userDataAdapter.GetById(id);
        }

        [HttpPost]
        public HttpResponseMessage Post(string name)
        {
            var newUser = new DataUser()
            {
                Name = name
            }; 

            _userDataAdapter.Insert(newUser);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public void Delete(DataUser user)
        {
            _userDataAdapter.Delete(user);
        }
    }
}
