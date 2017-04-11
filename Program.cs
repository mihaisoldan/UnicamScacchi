using System;
using Scacchi.Modello;

namespace Scacchi
{
    class Program
    {
        static void Main(string[] args)
        {
           // SimpleXUnitRunner.SimpleXUnit.RunTests();
           IOrologio orologio = new Orologio();
           orologio.Accendi();
           orologio.Avvia();
           orologio.TempoScaduto += NotificaSconfitta;
            Console.ReadKey();
        }

        private static void NotificaSconfitta(object sender, Colore colore)
        {
            Console.WriteLine($"Il giocatore {colore} ha perso la partita");
        }
    }
}
