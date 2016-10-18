using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Business;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;
using AutoMapper;

//REFACTOR ALL TO ABSTRACT FACTORIES!!!!!!!!!!!!!

namespace ToDoMVC.Infrastructure
{
    public class ItemFactory
    {
        private ToDoMVCEntities CreateItemDbSet()
        {
            return new ToDoMVCEntities();
        }

        internal IRepository<Item> CreateItemRepository()
        {
            var items = CreateItemDbSet();

            return new ItemRepository(items);
        }

        private IMapper CreateDTOMapper()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Item, DataItem>());

            return new Mapper(mapper);
        }

        private IMapper CreateItemMapper()
        {
            var othermap = new MapperConfiguration(x => x.CreateMap<DataItem, Item>());

            return new Mapper(othermap);
        }

        private IUnitOfWork CreateUnitOfWork()
        {
            var userFactory = new UserFactory();
            var todoFactory = new ToDoFactory();

            return new UnitOfWork(userFactory.CreateUserRepository(), todoFactory.CreateToDoRepository(), CreateItemRepository());
        }

        public IDataAdapter<DataItem> CreateItemAdapter()
        {
            var uow = CreateUnitOfWork();
            var mapper = CreateDTOMapper();
            var backMapper = CreateItemMapper();

            return new ItemDataAdapter(uow, mapper, backMapper);
        }
    }
}
