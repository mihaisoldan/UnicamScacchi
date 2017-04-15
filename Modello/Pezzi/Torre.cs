using System;

namespace Scacchi.Modello.Pezzi{
  public class Torre : IPezzo
  {
    private readonly Colore colore;

    public Torre(Colore colore){
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
    IScacchiera scacchiera)
    {
      var stessaColonna = colonnaPartenza == colonnaArrivo;
      var stessaTraversa = traversaPartenza == traversaArrivo;

      if(stessaColonna && stessaTraversa)
        return false;
      if(stessaColonna){
        int verso = Math.Sign(traversaArrivo - traversaPartenza);
        for(int i = (int) traversaPartenza + verso;;i += verso){
          if(i == (int) traversaArrivo){
            IPezzo pezzoSullaCasaDiArrivo = scacchiera[colonnaPartenza,(Traversa) i].PezzoPresente;
            if(pezzoSullaCasaDiArrivo == null)
              return true;
            return pezzoSullaCasaDiArrivo.Colore != colore? true : false;
          }
          if(scacchiera[colonnaPartenza,(Traversa) i].PezzoPresente != null)
            return false;
        }
      } 
      if(stessaTraversa){
        int verso = Math.Sign(colonnaArrivo - colonnaPartenza);
        for(int i = (int)colonnaPartenza + verso;;i += verso){
          if(i == (int) colonnaArrivo){
            IPezzo pezzoSullaCasaDiArrivo = scacchiera[(Colonna) i,traversaPartenza].PezzoPresente;
            if(pezzoSullaCasaDiArrivo == null)
              return true;
            return pezzoSullaCasaDiArrivo.Colore != colore? true : false;
          } 
          if(scacchiera[(Colonna) i,traversaPartenza].PezzoPresente != null)
            return false;
        }
      }
      //per far contento il compilatore
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
