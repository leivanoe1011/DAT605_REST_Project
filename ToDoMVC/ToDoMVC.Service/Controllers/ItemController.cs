using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;

namespace ToDoMVC.Service.Controllers
{
    public class ItemController : ApiController
    {
        private IDataAdapter<ItemDto> _itemDataAdapter;

        public ItemController(IDataAdapter<ItemDto> itemDataAdapter)
        {
            _itemDataAdapter = itemDataAdapter;
        }

        public ItemController()
        {
            //default for testing only
        }

        public IEnumerable<ItemDto> Get()
        {
            return _itemDataAdapter.GetAll();
        }

        public ItemDto Get(int id)
        {
            return _itemDataAdapter.GetById(id);
        }

        public void Post(ItemDto item)
        {
            _itemDataAdapter.Insert(item);
        }

        public void Delete(ItemDto item)
        {
            _itemDataAdapter.Delete(item);
        }
    }
}
