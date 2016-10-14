using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ToDoMVC.Contracts
{
    public interface IDataAdapter<T>
    {

        /// <summary>
        /// Responsibilities:
        /// Interface for business adapters classes to map DBSet and DTO objects.
        /// 
        /// Implemented By:
        /// Business Adapters
        /// 
        /// Used By:
        /// Service Controllers
        /// </summary>

        void Insert(T entity);
        void Delete(T entity);
        IEnumerable<T> SearchFor();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
