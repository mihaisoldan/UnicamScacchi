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
    IScacchiera scacchiera)
    {
      var distanzaTraLeColonne = Math.Abs(colonnaPartenza - colonnaArrivo);
      var distanzaTraLeTraverse = Math.Abs(traversaPartenza - traversaArrivo);
      //controllo se lo spostamento è 2x1
      if((distanzaTraLeColonne==2 && distanzaTraLeTraverse==1)||(distanzaTraLeTraverse==2 && distanzaTraLeColonne ==1)){
        IPezzo pezzoPresente = scacchiera[colonnaArrivo, traversaArrivo].PezzoPresente;
        //controllo pezzo non presente
        if(pezzoPresente == null)
          return true;
        //pezzo del avversario
        if(pezzoPresente.Colore != colore)
          return true;
        return false;
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
