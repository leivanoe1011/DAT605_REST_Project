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
    public class UserDataAdapter : IDataAdapter<DTOUser>
    {
        private readonly IRepository<User> _repository;

        public UserDataAdapter(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Insert(DTOUser entity)
        {
            var user = new User();

            _repository.Insert(user);
        }

        public void Delete(DTOUser entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTOUser> SearchFor()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTOUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public DTOUser GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
