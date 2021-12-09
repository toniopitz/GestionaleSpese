using GestionaleSpese.Core.BusinessLayer;
using GestionaleSpese.Core.Entities;
using GestionaleSpese.Core.Interfaces;
using GestionaleSpese.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.ConsoleApp
{
    public class Menu 
    {
        public static readonly IBusinessLayer mainBl = new BusinessLayer(new MockCategoriaRepository(), new MockSpeseRepository(), new MockUtenteRepository());

        internal static void Start()
        {
            int scelta;

            do
            {
                //HO CERCATO DI UTILIZZARE DOVE RIUSCIVO A RICORDARMI LINKQ
                //HO AVUTO DIFFICOLTA' NEL DOVE CREARE I METODI
                //NELLO SVILUPPO NON PENSO DI AVERE TROPPI PROBLEMI
                //NON HO IMPLEMENTATO DEI CONTROLLI PARTICOLARI 
                //PER RECUPERARE QUASI TUTTI I PUNTI PER AVER PERSO TEMPO ALL'INIZI
                Console.WriteLine("Benvenuto nel gestionale spese. \n" +
                    " Premi uno dei numeri in riferimento all'operazione da svolgere. \n" +
                    " 1 - Inserire una nuova spesa. \n" +
                    " 2 - Approva una spesa. \n" +
                    " 3 - Visualizza una spesa. \n" +
                    " 4 - Visualizzare l'elenco delle spese approvate nel mese precedente. \n" +
                    " 5 - Visualizzare l'elenco delle spese di uno specifico utente. \n" +
                    " 6 - Visualizzare il totale delle spese per categoria nel mese precedente. \n" +
                    " 7 - Visualizzare le spese registrate, ordinate dalla più recente alla meno recente. \n" +
                    " 8 - Esci dal programma.");
                scelta = int.Parse(Console.ReadLine());

                switch (scelta)
                {
                    case 1:
                        //COMPLETATO
                        InsertNewSpesa();
                        break;
                    case 2:
                        //COMPLETATO
                        ApprovaSpesa();
                        break;
                    case 3:
                        //COMPLETATO
                        VisualizzaSpesa();
                        break;
                    case 4:
                        //COMPLETATO
                        SpeseApprovateMesePrec();
                        break;
                    case 5:
                        //COMPLETATO
                        SpeseUtente();
                        break;
                    case 6:
                        TotSpeseCatMesePrecedente();
                        break;
                    case 7:
                        SpeseOrdinate();
                        break;
                        
                }



            } while (scelta != 8);

        }

        private static void SpeseOrdinate()
        {
            List<Spese> speseOrdinate = mainBl.GetSpeseOrdinate();
            foreach(Spese spesa in speseOrdinate)
            {
                Console.WriteLine(spesa);
            }
        }

        private static void TotSpeseCatMesePrecedente()
        {
            Console.WriteLine("Quale totale vuoi vedere?(Inserisci l'id)");
            List<Categoria> categorie = mainBl.GetAllCategorie();
            foreach(Categoria cat in categorie)
            {
                Console.WriteLine(cat);
            }
            int idCat = int.Parse(Console.ReadLine());

            decimal totSpeseCat = mainBl.TotSpeseCatMesePrecedente(idCat);
            Console.WriteLine($"Il totale spese della categoria con id {idCat} è di {totSpeseCat} Euro");
        }

        private static void SpeseUtente()
        {
            Console.WriteLine("Di quale utente vuoi visualizzare le spese?(Inserisci l'id) \n");
            List<Utente> utenti = mainBl.GetAllUtenti();
            foreach (Utente u in utenti)
            {
                Console.WriteLine(u);
            }
            Console.WriteLine("\n");
            int id = int.Parse(Console.ReadLine());
            List<Spese> speseUt = mainBl.GetSpeseByUt(id);
            Console.WriteLine($"Le spese fatte dall'utente con id {id} sono : \n");
            foreach (Spese spesa in speseUt)
            {

                Console.WriteLine($"{spesa} \n");
            }
            
        }

        private static void SpeseApprovateMesePrec()
        {
            List<Spese> speseMesePrec = mainBl.GetSpeseMesePrec();
            foreach(Spese spesa in speseMesePrec)
            {
                Console.WriteLine(spesa);
            }
        }

        private static void VisualizzaSpesa()
        {
            List<Spese> speseLista = mainBl.GetAllSpese();
            Console.WriteLine("Inserisci l'id della spesa che vuoi visualizzare");
            foreach(Spese spesa in speseLista)
            {
                Console.WriteLine(spesa.Id + "\n");
            }
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(mainBl.GetSpesaById(id));
        }

        private static void ApprovaSpesa()
        {
            List<Spese> speseNon = mainBl.GetSpeseNonApprovate();
            Console.WriteLine("Spese ancora da approvare \n");
            foreach (Spese spesa in speseNon)
            Console.WriteLine(spesa + "\n");


            Console.WriteLine("Inserisci l'id della spesa che vuoi approvare");
            int id = int.Parse(Console.ReadLine()); 
            Spese spesaSelezionata = mainBl.GetSpesaById(id);
            if( spesaSelezionata == null)
            {
                Console.WriteLine("Spesa non trovata");
            }
            else
            {
                spesaSelezionata.Approvato = true;
                Console.WriteLine("Operazione riuscita");
            }


        }

        private static void InsertNewSpesa()
        {

            Console.WriteLine("Inserisci il tuo Id");
            int id = int.Parse(Console.ReadLine());
            Utente utenteRecuperato = mainBl.GetUtenteById(id);
            if(utenteRecuperato == null)
            {
                Console.WriteLine("Utente non trovato\n");
            }
            else
            {
                Console.WriteLine($"Utente {utenteRecuperato.Name} {utenteRecuperato.Cognome} VERIFICATO \n");
                int nCategorie = mainBl.GetAllCategorie().Count();
                List<Spese> speseList = InMemoryStorage.SpeseList;
                Spese newSpesa = new Spese();
                newSpesa.Id = speseList.Count + 1;
                Console.WriteLine("Inserisci la data in cui è stata effettuata la spesa");
                newSpesa.Data = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci la descrizione della spesa");
                newSpesa.Descrizione = Console.ReadLine();
                Console.WriteLine("Inserisci l'importo della spesa");
                newSpesa.Importo = int.Parse(Console.ReadLine());
                newSpesa.Approvato = false;
                newSpesa.UtenteId = utenteRecuperato.Id;
                do
                {
                    Console.WriteLine("Inserisci la cateogoria :  \n" +
                                        " 1 - Per Alimentari \n" +
                                        " 2 - Per Mezzi di trasporto \n" +
                                        " 3 - Per Tasse/Bollette \n" +
                                        " 4 - Per Svago \n");
                    id = int.Parse(Console.ReadLine());
                    Categoria categoriaSelezionata = mainBl.GetCategoriaById(id);
                    if (categoriaSelezionata != null)
                    {
                        newSpesa.CategoriaId = id;
                    }
                    else
                    {
                        Console.WriteLine("La spesa inserita non è valida \n");
                    }
                } while (id < 0 && id > nCategorie);
                if (newSpesa != null)
                {
                    mainBl.InsertNewSpesa(newSpesa);
                    Console.WriteLine("Inserimento avvenuto con successo");
                }
                else
                {
                    Console.WriteLine("Errore nell'inserimento");
                }
                Console.WriteLine($"Riepilogo Spesa \n {newSpesa} \n");
            }  
        }

    }
}
