using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;

namespace ToDoMVC.Persistence
{
    public class ReadUsersFromDatabase<T> : IRead<T> where T : User
    {

        public IEnumerable ReadEnumerable() 
        {
            using (var context = new ToDoMVCEntities())
            {
                var query = from a in context.Users
                    select a;

                return query;
            }
        }

        public IList ReadList() 
        {
            using (var context = new ToDoMVCEntities())
            {
                var query = from a in context.Users
                    select new User()
                    {
                        Name = a.Name
                    };
                                 
                return query.ToList();
            }
        }

        public IQueryable ReadQueryable()
        {
            using (var context = new ToDoMVCEntities())
            {
                var query = from a in context.Users
                    select a;

                return query;
            }
        }
    }
}
