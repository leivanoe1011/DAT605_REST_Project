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

//REFACTOR ALL TO ABSTRACT FACTORIES!!!!!!!!!!!!!

namespace ToDoMVC.Infrastructure
{
    public class ItemFactory
    {
        public ItemFactory()
        {
            
        }

        private DbSet<Item> CreateItemDbSet()
        {
            return new ToDoMVCEntities().Items;
        }

        private IRepository<Item> CreateItemRepository()
        {
            var items = CreateItemDbSet();

            return new ItemRepository(items);
        }

        private IDataMapper<Item, DataItem> CreateItemMapper()
        {
            return new ItemDataMapper();
        }

        public IDataAdapter<DataItem> CreateItemAdapter()
        {
            var repos = CreateItemRepository();
            var mapper = CreateItemMapper();

            return new ItemDataAdapter(repos, mapper);
        }
    }
}
