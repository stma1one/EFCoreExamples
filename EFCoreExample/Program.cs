using EFCoreExample.Models;
using Microsoft.IdentityModel.Tokens;

namespace EFCoreExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           HighScoresContext context = new HighScoresContext();
            try
            {
                foreach (var game in context.AllGamesByMinimumAge(7))
                {
                    Console.WriteLine($"{game.Name}  {game.MinimumAge}");
                }
              
            }


            catch (Exception ex) { Console.WriteLine(ex.Message); }
        
            Game g=new Game() { Name="Fortnite      ", MinimumAge = 7 };
            
            context.AddGame(g);

            try
            {
                Console.WriteLine("-----after adding game------"  );
                foreach (var game in context.AllGamesByMinimumAge(7))
                {
                    Console.WriteLine($"{game.Name}  {game.MinimumAge}");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


            //context.RemoveGame(g);  
            //try
            //{
            //    Console.WriteLine("-----after Removing game------");
            //    foreach (var game in context.AllGamesByMinimumAge(7))
            //    {
            //        Console.WriteLine($"{game.Name}  {game.MinimumAge}");
            //    }

            //}
            //catch (Exception ex) { Console.WriteLine(ex.Message); }

            context.UpdateMinimumAge(g, 10);

            try
            {
                Console.WriteLine("-----after Removing game------");
                foreach (var game in context.AllGamesByMinimumAge(7))
                {
                    Console.WriteLine($"{game.Name}  {game.MinimumAge}");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        
       
      
    }
}