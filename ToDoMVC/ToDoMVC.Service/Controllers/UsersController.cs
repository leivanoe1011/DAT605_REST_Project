using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoMVC.Contracts;
using ToDoMVC.Business;
using ToDoMVC.Persistence;
using ToDoMVC.Domain;

namespace ToDoMVC.Service.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IQuery<DTOUser> _query;

        public UsersController(IQuery<DTOUser> query)
        {
            _query = query;
        }

        public UsersController()
        {
            IRead<User> dbRead = new ReadUsersFromDatabase();
            _query = new UserQuery(dbRead);
        }
        
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<DTOUser> GetAllUsers()
        {
            var users = _query.ReturnAll();

            foreach (var i in users)
            {
                Trace.WriteLine(i.Name);
            }

            return users;
        }
    }
}
