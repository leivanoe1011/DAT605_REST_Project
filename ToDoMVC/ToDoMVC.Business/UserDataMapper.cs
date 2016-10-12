using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;

namespace ToDoMVC.Business
{
    public class UserDataMapper : IDataMapper<User, DataUser>
    {
        private readonly IDataMapper<ToDo, DataToDo> _iDataMapper;

        public UserDataMapper(IDataMapper<ToDo, DataToDo> iDataMapper)
        {
            _iDataMapper = iDataMapper;
        }

        public UserDataMapper()
        {
            
        }
        
        
        public User MapToObject(DataUser obj)
        {
            var user = new User {Name = obj.Name};
            
            return user;
        }

        public IList<User> MapToDto(IEnumerable<DataUser> obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> MapToDto(IQueryable<DataUser> obj)
        {
            throw new NotImplementedException();
        }
    }
}
