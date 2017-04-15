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
    IScacchiera scacchiera)
    {
      return new Torre(colore).PuòMuovere(colonnaPartenza, traversaPartenza,
      colonnaArrivo, traversaArrivo,scacchiera) || new Alfiere(colore).
      PuòMuovere(colonnaPartenza, traversaPartenza,colonnaArrivo, traversaArrivo,scacchiera);
    }
    public override String ToString(){
      string name = "";
      name += this.GetType().Name[0];
      name+= this.colore == Colore.Bianco? "b" : "n";
      return name;
    }
  }
}
