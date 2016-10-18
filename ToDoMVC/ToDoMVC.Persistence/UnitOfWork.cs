using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;

namespace ToDoMVC.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<User> UserRepository { get; }
        public IRepository<ToDo> ToDoRepository { get; }
        public IRepository<Item> ItemRepository { get; }

        public UnitOfWork(IRepository<User> userRepository, IRepository<ToDo> toDoRepository, IRepository<Item> itemRepository)
        {
            UserRepository = userRepository;
            ToDoRepository = toDoRepository;
            ItemRepository = itemRepository;
        }

        public void Commit()
        {
            UserRepository.Save();
            ToDoRepository.Save();
            ItemRepository.Save();
        }
    }
}
