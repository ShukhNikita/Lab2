using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab2.Interface
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Create(T item);

        void Update(T item);

        void DeleteByTitem(IEnumerable<T> item);

        void DeleteById(int id);

        void Save();

    }
}
