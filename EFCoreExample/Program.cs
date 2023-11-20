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
                #region הדפסת משחקים
                //הדפסת משחקים
                foreach (var game in context.AllGamesByMinimumAge(7))
                {
                    Console.WriteLine($"{game.Name}  {game.MinimumAge}");
                }
                #endregion

                #region הוספת משחק באמצעות פעולות מובנות Add
                //הוספת משחק
                Game g = new Game() { Name = "Fortnite      ", MinimumAge = 7 };

                context.AddGame(g);
              

                //הדפסה אחרי הוספה
                Console.WriteLine("-----after adding game------");
                foreach (var game in context.AllGamesByMinimumAge(7))
                {
                    Console.WriteLine($"{game.Name}  {game.MinimumAge}");
                }
                #endregion

                #region עדכון רשומות

                //עדכון רשומות
                context.UpdateMinimumAge(g, 10);
                Console.WriteLine("-----after Updating game------");
                foreach (var game in context.AllGamesByMinimumAge(7))
                {
                    Console.WriteLine($"{game.Name}  {game.MinimumAge}");
                }
                #endregion

                #region ניתן לעדכן בפעולה אחת אובייקט מורכב
                //הכנסה כולל רשומות קשורות
                //בפעולת ההכנסה
                //מזהים גם שיש שחקן חדש
                //גם PlayerHighScore חדש
                //ההכנסה מבצעת הכל בשורה אחת
                Player p = new Player() { Name = "Talsi", BirthYear = 1976 };
                p.PlayerHighScores.Add(new PlayerHighScore() { GameId = 1, HighScore = 10000 });
                //הפעולה תיצור בדאטה בייס רשומה של שחקן וגם רשומה חדשה של תוצאת משחק המקושרת לאותו
                //שחקן
                context.AddPlayer(p);

                #endregion

                #region שליפת רשומות ממוינות
                //   מיון רשומות

                var scores = context.GetOrderedHighScores().ToList();
                foreach (var score in scores)
                {
                    Console.WriteLine($"{score.GameId}:{score.HighScore}");
                }
                //הפעולה לא מחזירה לי את נתוני השחקן. כי בברירת המחדל לא מוחזרות רשומות     
                //מקושרות
                Console.WriteLine($"Player Id: {scores[0].PlayerId} Player Details (ToString): {scores[0].Player}");
                //נקבל את הרשומות כולל פרטי השחקן
                scores=context.GetOrderedHighScoresWithPlayerDetails().ToList();
                Console.WriteLine($"Player Id: {scores[0].PlayerId} Player Details (ToString): {scores[0].Player.Name}");


                #endregion


                #region Include and IncludeThen
                var players =context.GetPlayerDetails().ToList();
                foreach (var player in players)
                {
                    Console.WriteLine($"Player name:{player.Name}");
                    foreach (var highscore in player.PlayerHighScores)
                    {
                        Console.Write(highscore.Game.Name + ":");
                        Console.WriteLine(highscore.HighScore  );
                    }


                }


                #endregion

                #region asNoTracking() רק עבור שאילתות
                var games = context.GamesByScore();
                foreach ( var game in games )
                {
                    Console.WriteLine(game.Name);
                    foreach(var score in game.PlayerHighScores )
                    {
                        Console.WriteLine(  score.HighScore);
                    }
                }
                #endregion

            #region הוספה ישירות דרך טבלת השינויים
            Player player2 = new Player() { Name = "shoshke", BirthYear = 1900 };
               
    
                context.AddPlayer2(player2);
                #endregion
            }



            catch (Exception ex) { Console.WriteLine(ex.Message); }
        

           


          


            

            }
            
        }
        
       
}
