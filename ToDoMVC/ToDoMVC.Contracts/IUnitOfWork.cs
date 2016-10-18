using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using ToDoMVC.Persistence;

namespace ToDoMVC.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<ToDo> ToDoRepository { get; }
        IRepository<Item> ItemRepository { get; }

        void Commit();
    }
}
