using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVC.Contracts
{
    public interface IRead<T> where T : class
    {
        IQueryable ReadQueryable();
        IEnumerable ReadEnumerable();
        IList ReadList();
    }
}
