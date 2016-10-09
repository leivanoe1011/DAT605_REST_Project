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
        private readonly IDataMapper<DataItem, Item> _dataMapper;

        public ItemDataAdapter (IRepository<Item> repository, IDataMapper<DataItem, Item> dataMapper)
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
            var allItems = _repository.GetAll();

            return _dataMapper.MapToDto(allItems);
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
