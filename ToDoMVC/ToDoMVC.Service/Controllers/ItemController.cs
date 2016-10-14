using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.DynamicData;
using System.Web.Http;
using ToDoMVC.Business;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Infrastructure;

namespace ToDoMVC.Service.Controllers
{
    public class ItemController : ApiController
    {
        private readonly IDataAdapter<DataItem> _itemDataAdapter;
        private readonly ItemFactory _factory;

        public ItemController(IDataAdapter<DataItem> itemDataAdapter)
        {
            _itemDataAdapter = itemDataAdapter;
        }

        public ItemController()
        {
            _factory = new ItemFactory();
            _itemDataAdapter = _factory.CreateItemAdapter();
        }

        public IEnumerable<DataItem> Get()
        {
            return _itemDataAdapter.GetAll();
        }

        public DataItem Get(int id)
        {
            return _itemDataAdapter.GetById(id);
        }

        [HttpPost]
        public HttpResponseMessage Post(string name, string todo)
        {
            var newItem = new DataItem()
            {
                Name = name,
                ToDoName = todo
            };

            _itemDataAdapter.Insert(newItem);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Delete(string name)
        {
            var itemToDelete = new DataItem()
            {
                Name = name
            };


            _itemDataAdapter.Delete(itemToDelete);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
