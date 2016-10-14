using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;
using AutoMapper;

namespace ToDoMVC.Business
{
    public class ItemDataAdapter : IDataAdapter<DataItem>
    {
        private readonly IRepository<Item> _repository;
        private readonly IMapper _objectToDtoMapper;
        private readonly IMapper _dtoToObjectMapper;

        public ItemDataAdapter (IRepository<Item> repository, IMapper objectToDtoMapper, IMapper dtoToObjectMapper)
        {
            _repository = repository;
            _objectToDtoMapper = objectToDtoMapper;
            _dtoToObjectMapper = dtoToObjectMapper;
        }

        public void Delete(DataItem entity)
        {
            var allItems = _repository.GetAll().ToList();

            var itemToDelete = allItems.FirstOrDefault(x => x.Name.Equals(entity.Name));

            _repository.Delete(itemToDelete);
        }

        public IEnumerable<DataItem> GetAll()
        {
            var allItems = _repository.GetAll();
            var dataObjects = new List<DataItem>();

            foreach (var i in allItems)
            {
                dataObjects.Add(_objectToDtoMapper.Map<Item, DataItem>(i));
            }

            return dataObjects;
        }

        public DataItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DataItem entity)
        {
            _repository.Insert(_dtoToObjectMapper.Map<DataItem, Item>(entity));
        }

        public IEnumerable<DataItem> SearchFor()
        {
            throw new NotImplementedException();
        }
    }
}
