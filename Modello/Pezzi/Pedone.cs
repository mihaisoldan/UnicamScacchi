
namespace Scacchi.Modello.Pezzi {
    public class Pedone : IPezzo
    {
        private readonly Colore colore;
        public Pedone(Colore colore)
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
            Traversa traversaArrivo)
        {
            var stessaColonna = colonnaPartenza == colonnaArrivo;
            var distanzaTraLeTraverse = (int) traversaArrivo - (int) traversaPartenza;
            
            //caso bianco
            if(colore == Colore.Bianco)
                if (stessaColonna && (distanzaTraLeTraverse == 1 || 
                (traversaPartenza==Traversa.Seconda && distanzaTraLeTraverse == 2))){
                    return true;
                } else {
                    return false;
                }
            if (stessaColonna && (distanzaTraLeTraverse == -1 || 
                (traversaPartenza==Traversa.Settima && distanzaTraLeTraverse == -2))){
                return true;
            } else {
                return false;
            }

        }
    }
}