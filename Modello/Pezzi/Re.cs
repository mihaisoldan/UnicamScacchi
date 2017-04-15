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
      if(Math.Abs((int) (colonnaArrivo-colonnaPartenza) * 
      (int) (traversaArrivo -traversaPartenza)) <= 1)
        return new Donna(colore).PuòMuovere(colonnaPartenza, traversaPartenza,
      colonnaArrivo, traversaArrivo,scacchiera);
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
