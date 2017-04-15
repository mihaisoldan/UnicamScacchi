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
    IScacchiera scacchiera)
    {
      var distanzaTraLeColonne = colonnaArrivo - colonnaPartenza;
      int versoSpostamentoOrizzontale = Math.Sign(distanzaTraLeColonne);
      var distanzaTraLeTraverse = traversaArrivo - traversaPartenza;
      int versoSpostamentoVerticale = Math.Sign(distanzaTraLeTraverse);

      if(Math.Abs(distanzaTraLeColonne) != Math.Abs(distanzaTraLeTraverse) || distanzaTraLeColonne == 0)
        return false;
      int j = (int) traversaPartenza + versoSpostamentoVerticale;
      for(int i = (int)colonnaPartenza + versoSpostamentoOrizzontale;;){
        if( i== (int) colonnaArrivo){
          IPezzo pezzoSullaCasaDiArrivo = scacchiera[colonnaArrivo,traversaArrivo].PezzoPresente;
          if(pezzoSullaCasaDiArrivo == null)
            return true;
          return pezzoSullaCasaDiArrivo.Colore != colore? true : false;
        }
        if(scacchiera[(Colonna) i,(Traversa) j].PezzoPresente!=null)
          return false;
        i += versoSpostamentoOrizzontale;
        j += versoSpostamentoVerticale;
      }
    }

    public override String ToString(){
      string name = "";
      name += this.GetType().Name[0];
      name+= this.colore == Colore.Bianco? "b" : "n";
      return name;
    }
  }
}
