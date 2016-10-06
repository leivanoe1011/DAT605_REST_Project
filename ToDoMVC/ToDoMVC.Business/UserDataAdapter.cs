using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;

namespace ToDoMVC.Business
{
    public class UserDataAdapter : IDataAdapter<UserDto>
    {
        private readonly IRepository<User> _repository;

        public UserDataAdapter(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Insert(UserDto entity)
        {
            var user = new User();

            _repository.Insert(user);
        }

        public void Delete(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> SearchFor()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
