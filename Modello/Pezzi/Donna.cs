using System;

namespace Scacchi.Modello.Pezzi {
    public class Donna : IPezzo
    {
        private readonly Colore colore;
        public Donna(Colore colore)
        {
            this.colore = colore;    
        }
        public Colore Colore {
            get {
                return colore;
            }
        }
        public bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo,
            IScacchiera scacchiera = null)
        {
            var stessaColonna = colonnaPartenza == colonnaArrivo ;
            var stessaTraversa = traversaPartenza == traversaArrivo;
            var differenzaTraLeColonne = Math.Abs((int) colonnaArrivo - (int) colonnaPartenza) ;
            var differenzaTraLeTraverse = Math.Abs((int) traversaArrivo - (int) traversaPartenza) ;
            
           if((stessaColonna && differenzaTraLeTraverse!=0) || (stessaTraversa && differenzaTraLeColonne !=0) || (differenzaTraLeColonne == differenzaTraLeTraverse && differenzaTraLeColonne != 0)){
               return true;
           }else{
               return false;
           }
        }

    }
}