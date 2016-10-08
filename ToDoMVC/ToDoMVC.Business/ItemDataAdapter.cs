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
    public class ItemDataAdapter : IDataAdapter<DataItem>
    {
        private readonly IRepository<Item> _repository;
        private readonly IDataMapper<Item, DataItem> _dataMapper;

        public ItemDataAdapter (IRepository<Item> repository, IDataMapper<Item, DataItem> dataMapper)
        {
            _repository = repository;
            _dataMapper = dataMapper;
        }

        public void Delete(DataItem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataItem> GetAll()
        {
            var dataItems = new List<DataItem>();
            var allItems = _repository.GetAll();

            foreach (var i in allItems)
            {
                dataItems.Add(_dataMapper.MapToObject(i));
            }

            return dataItems;
        }

        public DataItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DataItem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataItem> SearchFor()
        {
            throw new NotImplementedException();
        }
    }
}
