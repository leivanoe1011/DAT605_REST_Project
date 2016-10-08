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
    public class ToDoController : ApiController
    {
        private IDataAdapter<DataToDo> _todoDataAdapter;

        public ToDoController(IDataAdapter<DataToDo> todoDataAdapter)
        {
            _todoDataAdapter = todoDataAdapter;
        }

        public ToDoController()
        {
            //defautl for testing only
        }

        public IEnumerable<DataToDo> Get()
        {
            return _todoDataAdapter.GetAll();
        }

        public DataToDo Get(int id)
        {
            return _todoDataAdapter.GetById(id);
        }

        public void Post(DataToDo todo)
        {
            _todoDataAdapter.Insert(todo);
        }

        public void Delete(DataToDo todo)
        {
            _todoDataAdapter.Delete(todo);
        }
    }
}
