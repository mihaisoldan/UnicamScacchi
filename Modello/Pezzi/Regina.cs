using System;

namespace Scacchi.Modello.Pezzi{
    public class Regina : IPezzo
    {
        private readonly Colore colore;

        public Regina(Colore colore){
            this.colore = colore;
        }

        public Colore Colore{
            get{
                return colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            var stessaColonna = colonnaPartenza == colonnaArrivo;
            var stessaTraversa = traversaPartenza == traversaArrivo;
            var distanzaTraLeColonne = Math.Abs(colonnaPartenza - colonnaArrivo);
            var distanzaTraLeTraverse = Math.Abs(traversaPartenza - traversaArrivo);

            if((distanzaTraLeColonne == distanzaTraLeTraverse && distanzaTraLeColonne!=0)||(stessaColonna ^ stessaTraversa))
                return true;
            return false;
        }
    }
}