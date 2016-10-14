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
using AutoMapper;

namespace ToDoMVC.Infrastructure
{
    public class UserFactory
    {
        private ToDoMVCEntities CreateUserDbSet()
        {
            return new ToDoMVCEntities();
        }

        private IRepository<User> CreateUserRepository()
        {
            var users = CreateUserDbSet();

            return new UserRepository(users);
        }

        private IMapper CreateDTOMapper()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<User, DataUser>());
            

            return new Mapper(mapper);
        }

        
        private IMapper CreateUserMapper()
        {
            var otherMap = new MapperConfiguration(x => x.CreateMap<DataUser, User>());

            return new Mapper(otherMap);
        }
        

        public IDataAdapter<DataUser> CreateUserAdapter()
        {
            var repos = CreateUserRepository();
            var mapper = CreateDTOMapper();
            var backMapper = CreateUserMapper();

            return new UserDataAdapter(repos, mapper, backMapper);
        }
    }
}
