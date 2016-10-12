using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;
using AutoMapper;


namespace ToDoMVC.Business
{
    public class UserDataAdapter : IDataAdapter<DataUser>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        private readonly IMapper _backMapper;

        public UserDataAdapter(IRepository<User> repository, IMapper mapper, IMapper backMapper)
        {
            _repository = repository;
            _mapper = mapper;
            _backMapper = backMapper;
        }

        public void Insert(DataUser entity)
        {
            _repository.Insert(_backMapper.Map<DataUser, User>(entity));
            //var userMapper = new UserDataMapper();
            //_repository.Insert(userMapper.MapToObject(entity));
        }

        public void Delete(DataUser entity)
        {
            throw new NotImplementedException();
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
                dataUsers.Add(_mapper.Map<User, DataUser>(i));
            }

            return dataUsers;
        }

        public DataUser GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
