using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;
using AutoMapper;



namespace ToDoMVC.Business
{

    /// <summary>
    /// Responsibility: 
    /// Map DBSet objects to Domain objects and visa versa via auto mapper library.
    /// 
    /// Interactions:
    /// ToDoMVC.Service Contollers
    /// ToDoMVC.Persistence Repositories
    /// </summary>

    public class UserDataAdapter : IDataAdapter<DataUser>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _objectToDtoMapper;
        private readonly IMapper _dtoToObjectMapper;

        public UserDataAdapter(IUnitOfWork uow, IMapper objectToDtoMapper, IMapper dtoToObjectMapper)
        {
            _uow = uow;
            _objectToDtoMapper = objectToDtoMapper;
            _dtoToObjectMapper = dtoToObjectMapper;
        }

        /// <summary>
        /// Map DTO to DBSet object and add into database via repository.
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(DataUser entity)
        {
            _uow.UserRepository.Insert(_dtoToObjectMapper.Map<DataUser, User>(entity));
        }

        /// <summary>
        /// Pull all DBSet Users from repository, find DBSet object equivalent to DTO, and delete from database via repository.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(DataUser entity)
        {
            var allUsers = _uow.UserRepository.GetAll().ToList();
            
            var userToDelete = allUsers.FirstOrDefault(x => x.Id.Equals(entity.Id));

            _uow.UserRepository.Delete(userToDelete);
        }

       
        /// <summary>
        /// Pull all DBSet Users from repository, map to DTO via automapper, return as List.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataUser> GetAll()
        {
            var allUsers = _uow.UserRepository.GetAll();
            var dataUsers = new List<DataUser>();

            foreach (var i in allUsers)
            {
                dataUsers.Add(_objectToDtoMapper.Map<User, DataUser>(i));
            }

            return dataUsers;
        }

        /// <summary>
        /// Search for specific User via number id. NYI
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataUser GetById(int id)
        {
            var allUsers = _uow.UserRepository.GetAll();

            return _objectToDtoMapper.Map<User, DataUser>(allUsers.FirstOrDefault(x => x.Id.Equals(id)));
        }

        public void Update(DataUser entity)
        {
            var allUsers = _uow.UserRepository.GetAll();

            var userToUpdate = allUsers.FirstOrDefault(x => x.Id.Equals(entity.Id));

            userToUpdate.Name = entity.Name;

            _uow.UserRepository.Save();
        }
    }
}
