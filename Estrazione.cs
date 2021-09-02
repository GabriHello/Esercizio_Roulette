using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Roulette
{
    class Estrazione
    {
        public Estrazione(int numeroEstratto, Colore colore, Dozzina dozzina)
        {
            NumeroEstratto = numeroEstratto;
            Colore = colore;
            Dozzina = dozzina;
        }

        public int NumeroEstratto { get; private set; }
        public Colore Colore { get; private set; }
        public Dozzina Dozzina { get; private set; }

        public override string ToString()
        {
            return $"Numero estratto: {NumeroEstratto} - Colore: {Colore} - {Dozzina} dozzina";
        }

    }
    enum Colore
    {
        verde,rosso,nero
    }
    enum Dozzina
    {
        Prima, Seconda, Terza, Zero
    }
    

}
