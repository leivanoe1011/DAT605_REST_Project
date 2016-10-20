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
using ToDoMVC.Service.Auth;


    /// <summary>
    /// Responsibilities:
    /// The controller that will be reference by the WebApiConfig cs.
    /// api/{Controller}/{Action}
    /// </summary>

namespace ToDoMVC.Service.Controllers
{
    [BasicAuth]
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

        /// HttpGet will be the action that will be referenced by the API call
        /// Then the method below will be called. 
        [HttpGet]
        public IEnumerable<DataItem> Get()
        {
            try
            {
                return _itemDataAdapter.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// HttpGet will be the action that will be referenced by the API call
        /// Then the method below will be called. 
        [HttpGet]
        public DataItem Get(int id)
        {
            try
            {
                return _itemDataAdapter.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// HttpPost will be the action that will be referenced by the API call
        /// Then the method below will be called. 
        [HttpPost]
        public HttpResponseMessage Post(string name, int todoid, int id)
        {
            try
            {
                var newItem = new DataItem()
                {
                    Name = name,
                    ToDoId = todoid,
                    Id = id,
                    isCompleted = 0
                };

                _itemDataAdapter.Insert(newItem);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// HttpDelete will be the action that will be referenced by the API call
        /// Then the method below will be called. 
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var itemToDelete = new DataItem()
                {
                    Id = id
                };


                _itemDataAdapter.Delete(itemToDelete);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// HttpPut will be the action that will be referenced by the API call
        /// Then the method below will be called. 
        [HttpPut]
        public HttpResponseMessage Put(int id, string name)
        {
            try
            {
                var itemToPut = new DataItem()
                {
                    Name = name,
                    Id = id,
                    isCompleted = 1
                };

                _itemDataAdapter.Update(itemToPut);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
