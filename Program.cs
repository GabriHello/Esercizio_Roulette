using System;

namespace Esercizio_Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Roulette GabRoulette = new Roulette();
            Giocatore giocatore = new Giocatore("pippo", "baudo");
            Console.WriteLine($"Budget del giocatore {giocatore.Nome} {giocatore.Cognome}: {giocatore.Budget}");
            string scelta = "0";
            string esito = "";


            while (scelta != "q" && giocatore.Budget > 1)
            {

                //stampa budget - ultime estrazioni - ultima puntata (non funziona se si ricomincia il gioco inviando "0"
                if (scelta != "0")
                {
                    Console.WriteLine($"Budget residuo: {giocatore.Budget}\n");
                    StampaUltimeTotEstrazioni(GabRoulette);
                    StampaUltimaPuntata(GabRoulette);
                }


                Console.WriteLine("" +
                    "\tPuoi giocare una partita scegliendo tra:\n" +
                    "(1) Puntare un numero esatto da 0 a 36 (vinci 36 volte la quota puntata)\n" +
                    "(2) Puntare su un colore - (vinci il doppio della quota puntata)\n" +
                    "(3) Punta su una dozzina - (vinci il triplo della quota puntata)\n");

                Estrazione estrazione = GabRoulette.NuovaEstrazione(); //automaticamente aggiunta alla lista di estrazioni



                while (scelta != "1" && scelta != "2" && scelta != "3" && giocatore.Budget>=1)
                {
                    scelta = Console.ReadLine().Trim();
                    switch (scelta)
                    {
                        case "1":
                            Puntata puntata = new Puntata(GabRoulette.PuntaNumero(), GabRoulette.ImpostaSommaPuntata(giocatore));
                            if (estrazione.NumeroEstratto == puntata.NumeroPuntato)
                            {
                                giocatore.Budget += puntata.SommaScommessa * 36;
                                puntata.Esito = Esito.Vinto;
                                esito = "Hai vinto";
                            }
                            else
                            {
                                puntata.Esito = Esito.Perso;
                                esito = "Hai perso";
                            }
                            GabRoulette.Puntate.Add(puntata);
                            break;
                        case "2":
                            puntata = new Puntata(GabRoulette.PuntaColore(), GabRoulette.ImpostaSommaPuntata(giocatore));
                            if(estrazione.Colore == puntata.Colore)
                            {
                                giocatore.Budget += puntata.SommaScommessa * 2;
                                puntata.Esito = Esito.Vinto;
                                esito = "Hai vinto";
                            }
                            else
                            {
                                puntata.Esito = Esito.Perso;
                                esito = "Hai perso";
                            }
                            GabRoulette.Puntate.Add(puntata);
                            break;
                        case "3":
                            puntata = new Puntata(GabRoulette.PuntaDozzina(), GabRoulette.ImpostaSommaPuntata(giocatore));
                            if (estrazione.Dozzina == puntata.Dozzina)
                            {
                                giocatore.Budget += puntata.SommaScommessa * 3;
                                puntata.Esito = Esito.Vinto;
                                esito = "Hai vinto";
                            }
                            else
                            {
                                puntata.Esito = Esito.Perso;
                                esito = "Hai perso";
                            }
                            GabRoulette.Puntate.Add(puntata);
                            break;
                        default:
                            Console.WriteLine("Attenzione! Scelta non valida");
                            break;
                    }
                }
                



                
                Console.WriteLine(esito + "\n" + estrazione + ((giocatore.Budget >=1)?"\nPremi INVIO per giocare ancora- (Q) per uscire" : "\n\n\t\tBancarotta!!!") );
                scelta = Console.ReadLine().Trim().ToLower();
                Console.Clear();
            }


        }

        public static void StampaUltimeTotEstrazioni(Roulette roulette)
        {
            int tot = roulette.Estrazioni.Count;
            Console.WriteLine (((tot>1)? $"\nUltime {tot} estrazioni: " : "\nUltima estrazione: "));
            for (int i = 0; i < tot; i++)
            {
                Console.WriteLine("> " + roulette.Estrazioni[roulette.Estrazioni.Count - (tot - i)]);
            }
        }
        public static void StampaUltimaPuntata(Roulette roulette)
        {
            int indice = roulette.Puntate.Count - 1;
            string puntata = "";
            TipoPuntata tipo = roulette.Puntate[indice].Tipo;
            if (tipo == TipoPuntata.NumeroEsatto) puntata = $"Numero puntato: {roulette.Puntate[indice].NumeroPuntato}\n";
            else if (tipo == TipoPuntata.Colore) puntata = $"Colore puntato: {roulette.Puntate[indice].Colore}\n";
            else if (tipo == TipoPuntata.Dozzina) puntata = $"Dozzina puntata: {roulette.Puntate[indice].Dozzina}\n";
            Console.WriteLine($"" +
                $"\nUltima puntata:\n" +
                $"Tipo: {roulette.Puntate[indice].Tipo}\n" +
                puntata + 
                $"Somma scommessa: {roulette.Puntate[indice].SommaScommessa}\n" +
                $"Esito: {roulette.Puntate[indice].Esito}\n");
        }
    }
}
