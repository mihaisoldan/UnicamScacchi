using System;
using Scacchi.Modello;

namespace Scacchi
{
  class Program
  {
    static void Main(string[] args)
    {

      //SimpleXUnitRunner.SimpleXUnit.RunTests();
      /*
      IOrologio orologio = new Orologio(TimeSpan.FromSeconds(5));
      orologio.Accendi();
      orologio.Avvia();
      orologio.TempoScaduto += NotificaSconfitta;
      */
      Scacchiera scacchiera = new Scacchiera();
      scacchiera.disponiPezziInConfigurazioneIniziale();
      scacchiera.visualizzaConfigurazione();
      Console.ReadKey();
    }
    /*
    private static void NotificaSconfitta(object sender, Colore colore)
    {
    Console.WriteLine($"(Dal metodo): Il giocatore {colore} ha perso la partita, secondo l'orologio {sender}!");
  }
  */

}
}
