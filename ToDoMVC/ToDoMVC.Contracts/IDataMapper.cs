using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVC.Contracts
{
    public interface IDataMapper<T, K>
    {
        T MapToDto(K obj);
        K MapToObject(T obj);
    }
}
