using System;

namespace Scacchi.Modello.Pezzi{
  public class Alfiere : IPezzo
  {
    private readonly Colore colore;

    public Alfiere(Colore colore){
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

      if(distanzaTraLeColonne == distanzaTraLeTraverse && distanzaTraLeColonne!=0)
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
