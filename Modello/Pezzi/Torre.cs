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
    IScacchiera scacchiera = null)
    {
      var stessaColonna = colonnaPartenza == colonnaArrivo;
      var stessaTraversa = traversaPartenza == traversaArrivo;

      if(stessaColonna ^ stessaTraversa)
      return true;
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
