using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.Core.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        public void Insert(T entity);
        IEnumerable<T> GetAllSelected(Func<T, bool> approvato);
    }
}
