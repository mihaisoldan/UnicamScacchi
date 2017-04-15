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

    public bool PuòMuovere(Colonna colonnaPartenza,
    Traversa traversaPartenza,
    Colonna colonnaArrivo,
    Traversa traversaArrivo,
    IScacchiera scacchiera)
    {
      var comeLaDonna = ((colonnaPartenza == colonnaArrivo && 
      Math.Abs(traversaPartenza - traversaArrivo) == 1) || 
      (traversaPartenza == traversaArrivo && 
      Math.Abs(colonnaArrivo -colonnaPartenza) ==1)) || 
      (Math.Abs(colonnaPartenza - colonnaArrivo) == 1 && 
      Math.Abs(traversaArrivo -traversaPartenza) == 1);
      return new Donna(colore).PuòMuovere(colonnaPartenza, traversaPartenza,
      colonnaArrivo, traversaArrivo,scacchiera);
    }
    public override String ToString(){
      string name = "";
      name += this.GetType().Name[0];
      name+= this.colore == Colore.Bianco? "b" : "n";
      return name;
    }
  }
}
