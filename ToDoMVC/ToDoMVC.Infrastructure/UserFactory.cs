using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Business;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;

namespace ToDoMVC.Infrastructure
{
    public class UserFactory
    {
        public UserFactory()
        {
            
        }

        private DbSet<User> CreateUserDbSet()
        {
            return new ToDoMVCEntities().Users;
        }

        private IRepository<User> CreateUserRepository()
        {
            var users = CreateUserDbSet();

            return new UserRepository(users);
        }

        public IDataAdapter<DataUser> CreateUserAdapter()
        {
            var repos = CreateUserRepository();

            return new UserDataAdapter(repos);
        }
    }
}
