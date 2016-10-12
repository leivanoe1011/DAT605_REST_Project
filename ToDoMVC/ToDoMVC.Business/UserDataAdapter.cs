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
    public class UserDataAdapter : IDataAdapter<DataUser>
    {
        private readonly IRepository<User> _repository;

        public UserDataAdapter(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Insert(DataUser entity)
        {
            throw new NotImplementedException();
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

            return null;
        }

        public DataUser GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
