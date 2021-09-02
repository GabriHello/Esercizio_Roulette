using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Roulette
{
    class Persona
    {
        public Persona(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }

        public string Nome { get; set; }
        public string Cognome { get; set; }

    }
}
