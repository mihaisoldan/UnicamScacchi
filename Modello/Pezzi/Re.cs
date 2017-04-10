using System;

namespace Scacchi.Modello.Pezzi{
    public class Re : IPezzo
    {
        private readonly Colore colore;

        public Re(Colore colore){
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

            if((distanzaTraLeColonne == distanzaTraLeTraverse && distanzaTraLeColonne==1)||(stessaColonna && distanzaTraLeTraverse==1) 
            || (stessaTraversa && distanzaTraLeColonne==1))
                return true;
            return false;
        }
    }
}