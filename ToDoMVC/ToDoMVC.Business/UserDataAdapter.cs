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

        public void Insert(DataUser entity)
        {
            _repository.Insert(_dtoToObjectMapper.Map<DataUser, User>(entity));
        }

        public void Delete(DataUser entity)
        {
            var allUsers = _repository.GetAll().ToList();
            
            var userToDelete = allUsers.FirstOrDefault(x => x.Name.Equals(entity.Name));

            _repository.Delete(userToDelete);
        }

        public IEnumerable<DataUser> SearchFor()
        {
            throw new NotImplementedException();
        }

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

        public DataUser GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
