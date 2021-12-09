using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.Core.Entities
{
    public class Utente 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cognome { get; set; }

        public override string ToString()
        {
            return $"Dati utente Id : {Id}, nome : {Name}, cognome : {Cognome}";  
        }
    }
}
