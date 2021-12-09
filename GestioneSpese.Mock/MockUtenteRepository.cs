using GestionaleSpese.Core.Entities;
using GestionaleSpese.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.Mock.Repositories
{
    public class MockUtenteRepository : IUtenteRepository
    {
        public List<Utente> GetAll()
        {
            return InMemoryStorage.Utenti;
        }

        public IEnumerable<Utente> GetAllSelected(Func<Utente, bool> approvato)
        {
            throw new NotImplementedException();
        }

        public Utente GetById(int id)
        {
            //FirstOrDefault è LinQ                     Lambda exp.
           return InMemoryStorage.Utenti.FirstOrDefault(u => u.Id == id);
        }

        public void Insert(Utente entity)
        {
            throw new NotImplementedException();
        }
    }
}
