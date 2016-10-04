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
    public class UsersController : ApiController
    {
        

        public UsersController()
        {
            
        }

        [HttpGet]
        public string GetAllUsers()
        {
            return "hi";
        }
    }
}
