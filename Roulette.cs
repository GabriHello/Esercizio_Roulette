using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Roulette
{
    class Roulette
    {
        public Roulette()
        {
            Estrazioni = new List<Estrazione>();
            Puntate = new List<Puntata>();
        }

        public List<Estrazione> Estrazioni { get; private set; }
        public List<Puntata> Puntate { get; private set; }

        public Colore AssegnaColore(int numero)
        {
            if (numero == 0) return Colore.verde;
            else if (numero % 2 == 0) return Colore.nero;
            else return Colore.rosso;
        }
        public Dozzina AssegnaDozzina(int numero)
        {
            if (numero == 0) return Dozzina.Zero;
            else if (numero >= 1 && numero <= 12) return Dozzina.Prima;
            else if (numero >= 13 && numero <= 24) return Dozzina.Seconda;
            else return Dozzina.Terza;
        }
        public Estrazione NuovaEstrazione()
        {
            Random N = new Random();
            int numero = N.Next(0, 37);
            Estrazione estrazione = new Estrazione(numero, AssegnaColore(numero), AssegnaDozzina(numero));
            Estrazioni.Add(estrazione);
            return estrazione;
        }

        public float ImpostaSommaPuntata(Giocatore giocatore)
        {
            float somma = 0;
            Console.Write("\nQuanti soldi vuoi puntare? (1-250 euro)");
            while (somma < 1 || somma > 250 || somma>giocatore.Budget)
            {
                try
                {
                    somma = float.Parse(Console.ReadLine().Trim());
                    if (somma < 1 || somma > 250) Console.WriteLine("Puntata non valida");
                    else if (somma > giocatore.Budget) Console.WriteLine("Budget insufficiente");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Errore: non è stato inserito un numero");
                }
            }
            giocatore.Budget -= somma;
            return somma;
        }
        public int PuntaNumero()
        {
            int numero = -1;
            Console.WriteLine("Puntata: numero esatto.\n" +
                "Punta su un numero da 0 a 36");
            while (numero < 0 || numero > 36)
            {
                try
                {
                    numero = int.Parse(Console.ReadLine().Trim());
                    if (numero < 0 || numero > 36) Console.WriteLine("Attenzione: inserire un numero da 0 a 36");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Errore: non è stato inserito un numero");
                }
            }
            return numero;
        }

        public Colore PuntaColore()
        {
            Colore colore = Colore.nero;
            Console.WriteLine("Punta un colore:\n" +
                "(1) Nero (numero pari)\n" +
                "(2) Rosso (numero dispari)");
            string scelta = "";
            while (scelta != "1" && scelta != "2")
            {
                scelta = Console.ReadLine().Trim();
                switch (scelta)
                {
                    case "1":
                        break;
                    case "2":
                        colore = Colore.rosso;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            }
            return colore;
        }
        public Dozzina PuntaDozzina()
        {
            Dozzina dozzina = Dozzina.Zero;
            Console.WriteLine("Punta una dozzina:\n" +
                "(1) Prima dozzina (1-12)\n" +
                "(2) Seconda dozzina (13-24)\n" +
                "(3) Terza dozzina (25-36)");
            string scelta = "";
            while (scelta != "1" && scelta != "2" && scelta != "3")
            {
                scelta = Console.ReadLine().Trim();
                switch (scelta)
                {
                    case "1":
                        dozzina = Dozzina.Prima;
                        break;
                    case "2":
                        dozzina = Dozzina.Seconda;
                        break;
                    case "3":
                        dozzina = Dozzina.Terza;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            }
            return dozzina;
        }




    }
}
