using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;

namespace ToDoMVC.Business
{
    public class ItemDataMapper : IDataMapper<DataItem, Item>, IDbSetMapper<Item, DataItem>
    {
        public IList<DataItem> MapToDto(IEnumerable<Item> obj)
        {
            var returnList = new List<DataItem>();

            foreach (var i in obj)
            {
                returnList.Add(new DataItem() { Name = i.Name });
            }

            return returnList;
        }

        public IEnumerable<DataItem> MapToDto(IQueryable<Item> obj)
        {
            var returnList = new List<DataItem>();

            foreach (var i in obj)
            {
                returnList.Add(new DataItem() {Name = i.Name});
            }

            return returnList;
        }

        public IQueryable<Item> MapToObject(IEnumerable<DataItem> obj)
        {
            
            var returnItem = new List<Item>();

            foreach (var i in obj)
            {
                returnItem.Add(new Item() {Name = i.Name});
            }


            return returnItem.AsQueryable();
        }
    }
}
