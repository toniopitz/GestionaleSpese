﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleSpese.Core.Entities
{
    public class Spese 
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public decimal Importo { get; set; }
        public bool Approvato { get; set; }
        public int CategoriaId { get; set; }
        public int UtenteId { get; set; }

        public override string ToString()
        {
            return $"Id spesa : {Id}, Data spesa : {Data}, Descrizione : {Descrizione}, Importo : {Importo} €," +
                    $"Approvato : {Approvato}, ";
        }
    }
}
