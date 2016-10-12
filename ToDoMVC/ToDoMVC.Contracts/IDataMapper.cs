using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVC.Contracts
{
    public interface IDataMapper<D, O>
    {
        IList<D> MapToDto(IEnumerable<O> obj);
        IEnumerable<D> MapToDto(IQueryable<O> obj);
    }
}
