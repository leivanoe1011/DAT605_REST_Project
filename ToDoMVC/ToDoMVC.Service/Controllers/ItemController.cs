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

        [HttpGet]
        public IEnumerable<DataItem> Get()
        {
            return _itemDataAdapter.GetAll();
        }

        [HttpGet]
        public DataItem Get(int id)
        {
            return _itemDataAdapter.GetById(id);
        }

        [HttpPost]
        public HttpResponseMessage Post(string name, int todoid, int id)
        {
            var newItem = new DataItem()
            {
                Name = name,
                ToDoId = todoid,
                Id = id
            };

            _itemDataAdapter.Insert(newItem);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var itemToDelete = new DataItem()
            {
                Id = id
            };


            _itemDataAdapter.Delete(itemToDelete);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, string name)
        {
            var itemToPut = new DataItem()
            {
                Name = name,
                Id = id
            };

            _itemDataAdapter.Update(itemToPut);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
