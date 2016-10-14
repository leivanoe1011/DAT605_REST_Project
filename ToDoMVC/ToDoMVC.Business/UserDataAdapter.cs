using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
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
        private readonly IRepository<User> _repository;
        private readonly IMapper _objectToDtoMapper;
        private readonly IMapper _dtoToObjectMapper;

        public UserDataAdapter(IRepository<User> repository, IMapper objectToDtoMapper, IMapper dtoToObjectMapper)
        {
            _repository = repository;
            _objectToDtoMapper = objectToDtoMapper;
            _dtoToObjectMapper = dtoToObjectMapper;
        }

        /// <summary>
        /// Map DTO to DBSet object and add into database via repository.
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(DataUser entity)
        {
            _repository.Insert(_dtoToObjectMapper.Map<DataUser, User>(entity));
        }

        /// <summary>
        /// Pull all DBSet Users from repository, find DBSet object equivalent to DTO, and delete from database via repository.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(DataUser entity)
        {
            var allUsers = _repository.GetAll().ToList();
            
            var userToDelete = allUsers.FirstOrDefault(x => x.Name.Equals(entity.Name));

            _repository.Delete(userToDelete);
        }

        /// <summary>
        /// Search for range of Users. NYI
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataUser> SearchFor()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pull all DBSet Users from repository, map to DTO via automapper, return as List.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataUser> GetAll()
        {
            var allUsers = _repository.GetAll();
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
            throw new NotImplementedException();
        }
    }
}
