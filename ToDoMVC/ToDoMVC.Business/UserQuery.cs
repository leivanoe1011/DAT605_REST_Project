using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Persistence;
using ToDoMVC.Domain;

namespace ToDoMVC.Business
{
    public class UserQuery : IQuery<DTOUser> 
    {
        private readonly IRead<User> _dbRead;

        public UserQuery(IRead<User> dbRead)
        {
            _dbRead = dbRead;
        }

        public IEnumerable<DTOUser> ReturnAll()
        {
            IList<DTOUser> users = new List<DTOUser>();

            foreach (var i in _dbRead.ReadEnumerable())
            {
                users.Add(new DTOUser()
                {
                    Name = i.Name,
                    //ToDos = i.ToDoes
                });
            }

            return users;
        }
    }
}
