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
        //private readonly IDataMapper<DataItem, Item> _dataMapper;
        private readonly IMapper _mapper;

        public ItemDataAdapter (IRepository<Item> repository, IMapper mapper)//IDataMapper<DataItem, Item> dataMapper)
        {
            _repository = repository;
            _mapper = mapper;
            //_dataMapper = dataMapper;
        }

        public void Delete(DataItem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataItem> GetAll()
        {
            var allItems = _repository.GetAll();
            var dataObjects = new List<DataItem>();

            

            foreach (var i in allItems)
            {
                dataObjects.Add(_mapper.Map<Item, DataItem>(i));
            }

            return dataObjects;
            //return _dataMapper.MapToDto(allItems);
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
