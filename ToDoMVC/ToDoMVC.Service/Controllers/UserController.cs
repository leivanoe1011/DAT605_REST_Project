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
        private IDataAdapter<DataUser> _userDataAdapter;

        public UserController()//IDataAdapter<UserDto> userDataAdapter)
        {
            var factory = new UserFactory();
            _userDataAdapter = factory.CreateUserAdapter();
        }

        public IEnumerable<DataUser> Get()
        {
            return _userDataAdapter.GetAll();
        }

        public DataUser Get(int id)
        {
            return _userDataAdapter.GetById(id);
        }

        public void Post(DataUser user)
        {
            _userDataAdapter.Insert(user);
        }

        public void Delete(DataUser user)
        {
            _userDataAdapter.Delete(user);
        }
    }
}
