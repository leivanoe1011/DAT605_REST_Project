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
        private readonly IUnitOfWork _uow;
        private readonly IMapper _objectToDtoMapper;
        private readonly IMapper _dtoToObjectMapper;

        public ItemDataAdapter (IUnitOfWork uow, IMapper objectToDtoMapper, IMapper dtoToObjectMapper)
        {
            _uow = uow;
            _objectToDtoMapper = objectToDtoMapper;
            _dtoToObjectMapper = dtoToObjectMapper;
        }

        public void Delete(DataItem entity)
        {
            var allItems = _uow.ItemRepository.GetAll().ToList();

            var itemToDelete = allItems.FirstOrDefault(x => x.Id.Equals(entity.Id));

            _uow.ItemRepository.Delete(itemToDelete);
        }

        public IEnumerable<DataItem> GetAll()
        {
            var allItems = _uow.ItemRepository.GetAll();
            var dataObjects = new List<DataItem>();

            foreach (var i in allItems)
            {
                dataObjects.Add(_objectToDtoMapper.Map<Item, DataItem>(i));
            }

            return dataObjects;
        }

        public DataItem GetById(int id)
        {
            var allItems = _uow.ItemRepository.GetAll();

            return _objectToDtoMapper.Map<Item, DataItem>(allItems.FirstOrDefault(x => x.Id.Equals(id)));
        }

        public void Update(DataItem entity)
        {
            var allItems = _uow.ItemRepository.GetAll();

            var itemToUpdate = allItems.FirstOrDefault(x => x.Id.Equals(entity.Id));

            itemToUpdate.Id = entity.Id;

            _uow.ItemRepository.Save();
        }

        public void Insert(DataItem entity)
        {
            _uow.ItemRepository.Insert(_dtoToObjectMapper.Map<DataItem, Item>(entity));
        }

       
    }
}
