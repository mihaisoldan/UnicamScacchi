using System;

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
    Traversa traversaArrivo,
    IScacchiera scacchiera)
    {
      var stessaColonna = colonnaPartenza == colonnaArrivo;
      var distanzaTraLeTraverse = (int) traversaArrivo - (int) traversaPartenza;

      //caso bianco
      if(colore == Colore.Bianco){
        //solo spostamento
        if(stessaColonna && scacchiera[colonnaArrivo,traversaArrivo].PezzoPresente == null){
          //spostamento in avanti di una casa
          if(distanzaTraLeTraverse == 1)
            return true;
          //spostamento in avanti di 2 case
          if(traversaPartenza==Traversa.Seconda && distanzaTraLeTraverse == 2
          && scacchiera[colonnaArrivo,traversaArrivo-1].PezzoPresente == null)
            return true;
        }
        //caso in cui un pezzo avversario viene mangiato
        if(Math.Abs((int) colonnaArrivo - (int) colonnaPartenza)==1 && 
        distanzaTraLeTraverse == 1){
          IPezzo pezzo = scacchiera[colonnaArrivo,traversaArrivo].PezzoPresente;
          if(pezzo == null)
            return false;
          if(pezzo.Colore != colore)
            return true;
        } 
        return false;
      }
      
      //caso nero
      if(stessaColonna && scacchiera[colonnaArrivo,traversaArrivo].PezzoPresente == null){
        //spostamento in avanti di una casa
        if(distanzaTraLeTraverse == -1)
          return true;
        //spostamento in avanti di 2 case
        if(traversaPartenza==Traversa.Settima && distanzaTraLeTraverse == -2
        && scacchiera[colonnaArrivo,traversaArrivo+1].PezzoPresente == null)
          return true;
      }
      //caso in cui un pezzo avversario viene mangiato
      if(Math.Abs((int) colonnaArrivo - (int) colonnaPartenza)==1 && 
      distanzaTraLeTraverse == -1){
        IPezzo pezzo = scacchiera[colonnaArrivo,traversaArrivo].PezzoPresente;
        if(pezzo == null)
          return false;
        if(pezzo.Colore != colore)
          return true;
      } 
      return false;
    }

    public override String ToString(){
      string name = "";
      name += this.GetType().Name[0];
      name+= this.colore == Colore.Bianco? "b" : "n";
      return name;
     }
  }
}

