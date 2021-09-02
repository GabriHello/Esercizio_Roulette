using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Roulette
{
    class Puntata
    {
        public Puntata(int numero, float sommaScommessa, Colore colore)
        {
            NumeroPuntato = numero;
            SommaScommessa = sommaScommessa;
            Colore = colore;
        }
        public Puntata(int numero, float sommaScommessa)
        {
            NumeroPuntato = numero;
            SommaScommessa = sommaScommessa;
            Tipo = TipoPuntata.NumeroEsatto;
        }
        public Puntata(Colore colore, float sommaScommessa)
        {
            SommaScommessa = sommaScommessa;
            Colore = colore;
            Tipo = TipoPuntata.Colore; 
        }
        public Puntata(Dozzina dozzina, float sommaScommessa)
        {
            SommaScommessa = sommaScommessa;
            Dozzina = dozzina;
            Tipo = TipoPuntata.Dozzina;
        }

        public int NumeroPuntato { get; set; }
        public float SommaScommessa { get; set; }
        public Colore Colore { get; set; }
        public Dozzina Dozzina { get; set; }
        public TipoPuntata Tipo { get; set; }
        public Esito Esito { get; set; }

    }
    enum TipoPuntata
    {
        NumeroEsatto, Colore, Dozzina
    }
    enum Esito
    {
        Vinto, Perso
    }
}
