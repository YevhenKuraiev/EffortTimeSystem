using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Contracts.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T Element);

        void Delete(T Element);

        void Update(T Element);

        T GetByID(int ID);

        IEnumerable<T> GetAll();
    }
}
