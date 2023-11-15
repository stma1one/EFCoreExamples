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
                //הדפסת משחקים
                foreach (var game in context.AllGamesByMinimumAge(7))
                {
                    Console.WriteLine($"{game.Name}  {game.MinimumAge}");
                }

                //הוספת משחק
            Game g=new Game() { Name="Fortnite      ", MinimumAge = 7 };
            
            context.AddGame(g);
              
                //הדפסה אחרי הוספה
           Console.WriteLine("-----after adding game------"  );
          foreach (var game in context.AllGamesByMinimumAge(7))
                {
                    Console.WriteLine($"{game.Name}  {game.MinimumAge}");
                }

          //עדכון רשומות
            context.UpdateMinimumAge(g, 10);
                Console.WriteLine("-----after Updating game------");
                foreach (var game in context.AllGamesByMinimumAge(7))
                {
                    Console.WriteLine($"{game.Name}  {game.MinimumAge}");
                }

                //הכנסה כולל רשומות קשורות
                //בפעולת ההכנסה
                //מזהים גם שיש שחקן חדש
                //גם PlayerHighScore חדש
                //ההכנסה מבצעת הכל בשורה אחת
                Player p = new Player() { Name = "Talsi", BirthYear = 1976 };
                p.PlayerHighScores.Add(new PlayerHighScore() { GameId = 1, HighScore = 10000 });
                context.AddPlayer(p);
                //מיון רשומות
                var scores = context.GetOrderedHighScores();
                foreach (var score in scores) 
                {
                    Console.WriteLine($"{score.GameId}:{score.HighScore}");
                }
            }


            catch (Exception ex) { Console.WriteLine(ex.Message); }
        

           


          


            

            }
            
        }
        
       
      
    }
}