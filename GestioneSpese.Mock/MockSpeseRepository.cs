using GestionaleSpese.Core.Entities;
using GestionaleSpese.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.Mock.Repositories
{
    public class MockSpeseRepository : ISpeseRepository
    {
        public List<Spese> GetAll()
        {
            return InMemoryStorage.SpeseList;
        }

        public List<Spese> GetAllNonApprovate()
        {
            return GetAll().Where(s => s.Approvato == false).ToList();
        }

        public IEnumerable<Spese> GetAllSelected(Func<Spese, bool> approvato)
        {
            var speseNon = InMemoryStorage.SpeseList.Where(approvato).ToList();
            return speseNon;
        }

        public Spese GetById(int id)
        {
            return InMemoryStorage.SpeseList.FirstOrDefault(s => s.Id == id);
        }

        public List<Spese> GetPerCategoria(Func<Spese, decimal> id)
        {
            //var spesePerCat = InMemoryStorage.SpeseList.Where(s => s.Equals(id)).Sum(tot => tot.Importo).OrderBy(id).ToList();//.Sum(s => s.Importo);
            return null;
        }

        public List<Spese> GetPerCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public List<Spese> GetSpeseByUt(int id)
        {
            return InMemoryStorage.SpeseList.Where(s => s.UtenteId == id).ToList();
        }

        public List<Spese> GetSpeseMesePrec()
        {
            var speseMesePrec = InMemoryStorage.SpeseList.Where(s => s.Data.Month == DateTime.Now.AddMonths(-1).Month).ToList();
            return speseMesePrec;
        }

        public void Insert(Spese entity)
        {
            InMemoryStorage.SpeseList.Add(entity);
        }
    } 
}
