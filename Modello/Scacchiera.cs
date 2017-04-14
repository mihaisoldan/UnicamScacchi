using System;
using System.Collections.Generic;
using System.Linq;
using Scacchi.Modello.Pezzi;

namespace Scacchi.Modello {
  public class Scacchiera : IScacchiera
  {
    private ICasa[] listaCase;

    /*public Scacchiera(){
    listaCase= new ICasa[64];
    int contatore=0;
    for (int i = 1; i < 9; i++)
    {
    for (int j = 1; j < 9; j++,contatore++)
    {
    ICasa casa = new Casa((Colonna)j,(Traversa)i);
    listaCase[contatore] = casa;
  }
}

}*/

    public Scacchiera()
    {
      listaCase = Enumerable
      .Range(0, 64)
      .Select(i => (ICasa) new Casa((Colonna) (i%8+1), (Traversa) (i/8+1)))
      .ToArray();
    }
    public void disponiPezziInConfigurazioneIniziale(){
      foreach(Casa casa in listaCase){

        if(casa.Traversa==Traversa.Seconda)
        casa.PezzoPresente = new Pedone(Colore.Bianco);
        if(casa.Traversa==Traversa.Settima)
        casa.PezzoPresente = new Pedone(Colore.Nero);

        if(casa.Colonna == Colonna.A || casa.Colonna == Colonna.H){
          if(casa.Traversa == Traversa.Prima)
          casa.PezzoPresente = new Torre(Colore.Bianco);
          if(casa.Traversa == Traversa.Ottava)
          casa.PezzoPresente = new Torre(Colore.Nero);
        }

        if(casa.Colonna == Colonna.B || casa.Colonna == Colonna.G){
          if(casa.Traversa == Traversa.Prima)
          casa.PezzoPresente = new Cavallo(Colore.Bianco);
          if(casa.Traversa == Traversa.Ottava)
          casa.PezzoPresente = new Cavallo(Colore.Nero);
        }

        if(casa.Colonna == Colonna.C || casa.Colonna == Colonna.F){
          if(casa.Traversa == Traversa.Prima)
          casa.PezzoPresente = new Alfiere(Colore.Bianco);
          if(casa.Traversa == Traversa.Ottava)
          casa.PezzoPresente = new Alfiere(Colore.Nero);
        }
        if(casa.Colonna == Colonna.D){
          if(casa.Traversa == Traversa.Prima)
          casa.PezzoPresente = new Donna(Colore.Bianco);
          if(casa.Traversa == Traversa.Ottava)
          casa.PezzoPresente = new Donna(Colore.Nero);
        }
        if(casa.Colonna == Colonna.E){
          if(casa.Traversa == Traversa.Prima)
          casa.PezzoPresente = new Re(Colore.Bianco);
          if(casa.Traversa == Traversa.Ottava)
          casa.PezzoPresente = new Re(Colore.Nero);
        }
      }
    }
    public ICasa[] Case {
      get{
        return listaCase;
      }
    }

    public ICasa this[Colonna colonna, Traversa traversa] {
      get{
        return listaCase[(int) colonna-1+(((int) traversa-1)*8)];
      }
    }
    public void visualizzaConfigurazione(){
      int i = 1;
      System.Console.WriteLine("   | A  | B  | C  | D  | E  | F  | G  | H  |");
      System.Console.WriteLine("-------------------------------------------");
      foreach(Traversa traversa in Enum.GetValues(typeof(Traversa))){
        System.Console.Write($" {i} |");
        i++;
        foreach(Colonna colonna in Enum.GetValues(typeof(Colonna))){
          IPezzo pezzo = this[colonna,traversa].PezzoPresente;
          if(pezzo != null){
           System.Console.Write(string.Format(" {0} |",pezzo.ToString()));
          }
          else
            System.Console.Write(string.Format("    |"));
          
        }
        System.Console.WriteLine("\n-------------------------------------------");
      }
    }
  }
}
