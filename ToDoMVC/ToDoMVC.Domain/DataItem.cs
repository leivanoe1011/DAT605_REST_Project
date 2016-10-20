using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// <summary>
    /// Responsibilities:
    /// The Class will create the object that will
    /// make the entries in the DB.
    /// </summary>
namespace ToDoMVC.Domain
{
    public class DataItem
    {
        
        /// Below are the different columns that will be 
        /// stored in the DB.
        public string Name { get; set; }
        public int ToDoId { get; set; }
        public int Id { get; set; }
        //public virtual DataToDo ToDo { get; set; }
        public int isCompleted { get; set; }
    }
}

