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

    /// <summary>
    /// Responsibility:
    /// Factory for User entity classes.
    /// 
    /// Interactions:
    /// ToDoMVC.Service Controllers
    /// </summary>
    /// 
    public class UserFactory
    {

        /// <summary>
        /// Create instance of DBSet entities;
        /// </summary>
        /// <returns></returns>
        private ToDoMVCEntities CreateUserDbSet()
        {
            return new ToDoMVCEntities();
        }

        /// <summary>
        /// Use DBSet intities to create a new User repository;
        /// </summary>
        /// <returns></returns>
        private IRepository<User> CreateUserRepository()
        {
            var users = CreateUserDbSet();

            return new UserRepository(users);
        }

        /// <summary>
        /// Map User to DataUser and return Mapper class. 
        /// </summary>
        /// <returns></returns>
        private IMapper CreateDTOMapper()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<User, DataUser>());
            

            return new Mapper(mapper);
        }

        /// <summary>
        /// Map DataUser to User and return Mapper class.
        /// </summary>
        /// <returns></returns>
        private IMapper CreateUserMapper()
        {
            var otherMap = new MapperConfiguration(x => x.CreateMap<DataUser, User>());

            return new Mapper(otherMap);
        }
        
        /// <summary>
        /// Create a new UserDataAdapter with a repository, and two mapper classes.
        /// </summary>
        /// <returns></returns>
        public IDataAdapter<DataUser> CreateUserAdapter()
        {
            var repos = CreateUserRepository();
            var mapper = CreateDTOMapper();
            var backMapper = CreateUserMapper();

            return new UserDataAdapter(repos, mapper, backMapper);
        }
    }
}
