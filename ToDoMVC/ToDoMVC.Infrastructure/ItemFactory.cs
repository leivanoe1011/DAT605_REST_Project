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
        private DbSet<Item> CreateItemDbSet()
        {
            return new ToDoMVCEntities().Items;
        }

        private IRepository<Item> CreateItemRepository()
        {
            var items = CreateItemDbSet();

            return new ItemRepository(items);
        }

        private IMapper CreateItemMapper()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Item, DataItem>());

            return new Mapper(mapper);
        }

        public IDataAdapter<DataItem> CreateItemAdapter()
        {
            var repos = CreateItemRepository();
            var mapper = CreateItemMapper();

            return new ItemDataAdapter(repos, mapper);
        }
    }
}
