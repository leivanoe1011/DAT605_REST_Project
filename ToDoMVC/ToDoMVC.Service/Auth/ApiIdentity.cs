using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ToDoMVC.Service.Auth
{
    public class ApiIdentity : IIdentity
    {
        private string _user;

        public ApiIdentity(string user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user null");
            }
            else
            {
                _user = user;
            }
        }

        public string Name
        {
            get { return _user; }
        }

        public string AuthenticationType
        {
            get { return "Basic"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }
    }
}