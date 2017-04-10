using System;

namespace Scacchi.Modello.Pezzi{
    public class Alfiere : IPezzo
    {
        private readonly Colore colore;

        public Alfiere(Colore colore){
            this.colore = colore;
        }

        public Colore Colore{
            get{
                return colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            var distanzaTraLeColonne = Math.Abs(colonnaPartenza - colonnaArrivo);
            var distanzaTraLeTraverse = Math.Abs(traversaPartenza - traversaArrivo);

            if(distanzaTraLeColonne == distanzaTraLeTraverse)
                return true;
            return false;
        }
    }
}