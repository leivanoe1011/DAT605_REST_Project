using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;


namespace ToDoMVC.Persistence
{
    public class ReadUsersFromDatabase : IRead<User> 
    {

        public IEnumerable<User> ReadEnumerable() 
        {
            using (var context = new ToDoMVCEntities())
            {
                var query = from a in context.Users
                    select a;

                return query.ToList();
            }
        }
    }
}
