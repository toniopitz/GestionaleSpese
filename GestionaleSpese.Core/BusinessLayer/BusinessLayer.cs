using GestionaleSpese.Core.Entities;
using GestionaleSpese.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.Core.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ISpeseRepository _speseRepository;
        private readonly IUtenteRepository _utenteRepository;

        public BusinessLayer(ICategoriaRepository CategoriaRepository, ISpeseRepository SpeseRepository, IUtenteRepository UtenteRepository)
        {
            _categoriaRepository = CategoriaRepository;
            _speseRepository = SpeseRepository;
            _utenteRepository = UtenteRepository;
        }

        public List<Utente> GetAllUtenti()
        {
            return _utenteRepository.GetAll();
        }
        public Utente GetUtenteById(int id)
        {
            //Eseguo le operazioni
            return _utenteRepository.GetById(id);

        }
        public List<Categoria> GetAllCategorie()
        {
            return _categoriaRepository.GetAll();
        }
        public Categoria GetCategoriaById(int id)
        {
            return _categoriaRepository.GetById(id);
        }
        public void InsertNewSpesa(Spese newSpesa)
        {
            //Controlli da fare prima di inserire l'oggetto nel database vanno fatti nel BusinessLayer
            _speseRepository.Insert(newSpesa);
        }
        public Spese GetSpesaById(int id)
        {
            return _speseRepository.GetById(id);
        }
        public List<Spese> GetSpeseNonApprovate()
        {
            //return _speseRepository.GetAll().Where(s => s.Approvato == false).ToList();
            return _speseRepository.GetAllNonApprovate();
        }

        public List<Spese> GetAllSpese()
        {
            return _speseRepository.GetAll();
        }

        public List<Spese> GetSpeseMesePrec()
        {
           return _speseRepository.GetSpeseMesePrec();
        }

        public List<Spese> GetSpeseByUt(int id)
        {
            return _speseRepository.GetSpeseByUt(id);
        }

        public decimal TotSpeseCatMesePrecedente(int id)
        {
            return  GetSpeseMesePrec().Where(s => s.CategoriaId == id).Sum(s => s.Importo);
           
        }

        public List<Spese> GetSpeseOrdinate()
        {
            return GetAllSpese().OrderBy(s => s.Data).ToList();
        }
    }
}
