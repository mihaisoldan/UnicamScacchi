using System;

namespace Scacchi.Modello.Pezzi{
    public class Cavallo : IPezzo
    {
        private readonly Colore colore;

        public Cavallo(Colore colore){
            this.colore = colore;
        }

        public Colore Colore{
            get{
                return colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, 
        Traversa traversaPartenza, 
        Colonna colonnaArrivo, 
        Traversa traversaArrivo,
        IScacchiera scacchiera = null)
        {
            var distanzaTraLeColonne = Math.Abs(colonnaPartenza - colonnaArrivo);
            var distanzaTraLeTraverse = Math.Abs(traversaPartenza - traversaArrivo);

            if((distanzaTraLeColonne==2 && distanzaTraLeTraverse==1)||(distanzaTraLeTraverse==2 && distanzaTraLeColonne ==1))
                return true;
            return false;
        }
    }
}