using EFCoreExample.Models;
using Microsoft.IdentityModel.Tokens;

namespace EFCoreExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using( HighScoresContext db=new HighScoresContext())
            {
                try
                {
                    db.AddGame("Space Invaders", 4);
                      Console.WriteLine( "-------Add game------");
                    foreach(var game in db.Games)
                    {
                        Console.WriteLine($"{ game.Name},{game.MinimumAge}");
                    }
                }
                catch (Exception ex) { }

                try
                {
                    db.RemoveGame("Space Invaders");
                    Console.WriteLine("-------Remove game------");
                    foreach (var game in db.Games)
                    {
                        Console.WriteLine($"{game.Name},{game.MinimumAge}");
                    }

                }
                catch ( Exception ex) { }

            }
            
        }
    }
}