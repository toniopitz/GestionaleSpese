using GestionaleSpese.Core.Entities;
using GestionaleSpese.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.Mock.Repositories
{
    public class MockCategoriaRepository : ICategoriaRepository
    {
        public List<Categoria> GetAll()
        {
            return InMemoryStorage.Categorie;
        }

        public IEnumerable<Categoria> GetAllSelected(Func<Categoria, bool> approvato)
        {
            throw new NotImplementedException();
        }

        public Categoria GetById(int id)
        {
            return InMemoryStorage.Categorie.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
