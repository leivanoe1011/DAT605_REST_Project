using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Persistence;
using AutoMapper;
using ToDoMVC.Business;
using ToDoMVC.Domain;

namespace ToDoMVC.Infrastructure
{
    public class ToDoFactory
    {
        private ToDoMVCEntities CreateToDoDbSet()
        {
            return new ToDoMVCEntities();
        }

        internal IRepository<ToDo> CreateToDoRepository()
        {
            var todos = CreateToDoDbSet();

            return new ToDoRepository(todos);
        }

        private IMapper CreateDTOMapper()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<ToDo, DataToDo>());

            return new Mapper(mapper);
        }

        private IMapper CreateToDoMapper()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<DataToDo, ToDo>());

            return new Mapper(mapper);
        }

        private IUnitOfWork CreateUnitOfWork()
        {
            var itemFactory = new ItemFactory();
            var userFactory = new UserFactory();

            return new UnitOfWork(userFactory.CreateUserRepository(), CreateToDoRepository(), itemFactory.CreateItemRepository());
        }

        public IDataAdapter<DataToDo> CreateToDoAdapter()
        {
            var uow = CreateUnitOfWork();
            var mapper = CreateDTOMapper();
            var backMapper = CreateToDoMapper();

            return new ToDoDataAdapter(uow, mapper, backMapper);
        }
    }
}
