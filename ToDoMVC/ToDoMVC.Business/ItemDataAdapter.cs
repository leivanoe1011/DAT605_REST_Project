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
    class ItemDataAdapter : IDataAdapter<ItemDto>
    {
        private readonly IRepository<Item> _repository;

        public ItemDataAdapter (IRepository<Item> repository)
        {
            _repository = repository;
        }

        public void Delete(ItemDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ItemDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ItemDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemDto> SearchFor()
        {
            throw new NotImplementedException();
        }
    }
}
