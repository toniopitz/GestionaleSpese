using GestionaleSpese.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.Core.Interfaces
{
    public interface ISpeseRepository : IRepository<Spese>
    {
        List<Spese> GetAllNonApprovate();
        List<Spese> GetSpeseMesePrec();
        List<Spese> GetSpeseByUt(int id);
        List<Spese> GetPerCategoria(int id);
    }
}
