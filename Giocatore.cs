using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Roulette
{
    class Giocatore : Persona
    {
        public float Budget { get; set; }

        public Giocatore(string nome, string cognome, float budget) : base(nome, cognome)
        {
            Budget = budget;
        }
        public Giocatore(string nome, string cognome) : base(nome, cognome)
        {
            Budget = ImpostaBudget();
        }

        public float ImpostaBudget()
        {
            float budget = 0;
            byte budgetMin = 10;
            Console.WriteLine($"Imposta un budget di almeno {budgetMin}euro.");
            while (budget < budgetMin)
            {
                try
                {
                    budget = float.Parse(Console.ReadLine().Trim());
                    if (budget < budgetMin)
                        Console.WriteLine("Budget non sufficiente");
                }
                catch (FormatException)
                {
                    budget = 0;
                    Console.WriteLine("Errore! Inserire un formato valido");
                }
            }
            return budget;
        }


    }
}
