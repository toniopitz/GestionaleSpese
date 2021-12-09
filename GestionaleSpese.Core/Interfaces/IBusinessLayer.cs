using GestionaleSpese.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.Core.Interfaces
{
    public interface IBusinessLayer
    {
        Spese GetSpesaById(int id);
        List<Utente> GetAllUtenti();
        Utente GetUtenteById(int id);
        List<Categoria> GetAllCategorie();
        Categoria GetCategoriaById(int id);
        public void InsertNewSpesa(Spese entity);
        List<Spese> GetSpeseNonApprovate();
        List<Spese> GetAllSpese();
        List<Spese> GetSpeseMesePrec();
        List<Spese> GetSpeseByUt(int id);
        decimal TotSpeseCatMesePrecedente(int id);
        List<Spese> GetSpeseOrdinate();
    }
}
