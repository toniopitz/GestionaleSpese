using GestionaleSpese.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.Mock.Repositories
{
    public class InMemoryStorage
    {
        public static List<Utente> Utenti = new List<Utente>
        {
            new Utente()
            {
                Id = 1,
                Name = "Antonio",
                Cognome = "Pitzalis"
            },
            new Utente()
            {
                Id = 2,
                Name = "Francesco",
                Cognome = "Pitzalis"
            },
            new Utente()
            {
                Id = 3,
                Name = "Carlo",
                Cognome = "Fois"
            },
            new Utente()
            {
                Id = 4,
                Name = "Veronica",
                Cognome = "Pusceddu"
            }
            
        };
        public static List<Spese> SpeseList = new List<Spese>
        {
            new Spese()
            {
                Id = 1,
                Data = new DateTime(2021,11,20),
                Descrizione = "Cibo",
                Importo = 20,
                Approvato = true,
                CategoriaId = 1,
                UtenteId = 1
            },
            new Spese()
            {
                Id = 2,
                Data = new DateTime(2021,7,19),
                Descrizione = "Assicurazione",
                Importo = 250,
                Approvato = true,
                CategoriaId = 2,
                UtenteId = 3
            },
            new Spese()
            {
                Id = 3,
                Data = new DateTime(2021,2,20),
                Descrizione = "Bolletta luce",
                Importo = 160,
                Approvato = true,
                CategoriaId = 3,
                UtenteId = 4
            },
            new Spese()
            {
                Id = 4,
                Data = new DateTime(2021,2,20),
                Descrizione = "Messa a punto",
                Importo = 140,
                Approvato = true,
                CategoriaId = 2,
                UtenteId = 3
            },
            new Spese()
            {
                Id = 5,
                Data = new DateTime(2021,2,20),
                Descrizione = "Televisore LED FullHD",
                Importo = 2000,
                Approvato = false,
                CategoriaId = 4,
                UtenteId = 2
            },
            new Spese()
            {
                Id = 6,
                Data = new DateTime(2021,11,2),
                Descrizione = "Biliardo",
                Importo = 1700,
                Approvato = false,
                CategoriaId = 4,
                UtenteId = 3
            }

        };
        public static List<Categoria> Categorie = new List<Categoria>
        {
            new Categoria()
            {
                Id = 1,
                Nome = "Alimentari"
            },
              new Categoria()
            {
                Id = 2,
                Nome = "Mezzi di trasporto"
            },
                new Categoria()
            {
                Id = 3,
                Nome = "Tasse/Bollette"
            },
                  new Categoria()
            {
                Id = 4,
                Nome = "Svago"
            },
        };
    }
}
