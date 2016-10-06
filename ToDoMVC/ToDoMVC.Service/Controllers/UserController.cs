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

namespace ToDoMVC.Service.Controllers
{
    public class UserController : ApiController
    {
        private IDataAdapter<UserDto> _userDataAdapter;

        public UserController(IDataAdapter<UserDto> userDataAdapter)
        {
            _userDataAdapter = userDataAdapter;
        }

        public UserController()
        {
            //default for testing only
        }
        
        public IEnumerable<UserDto> Get()
        {
            return _userDataAdapter.GetAll();
        }

        public UserDto Get(int id)
        {
            return _userDataAdapter.GetById(id);
        }

        public void Post(UserDto user)
        {
            _userDataAdapter.Insert(user);
        }

        public void Delete(UserDto user)
        {
            _userDataAdapter.Delete(user);
        }
    }
}
