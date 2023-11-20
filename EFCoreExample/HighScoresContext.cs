using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreExample.Models
{
    public partial class HighScoresContext
    {

       public List<Game> AllGamesByMinimumAge(int age)
        {
            return this.Games.Where(x=>x.MinimumAge>=age).OrderBy(x=>x.MinimumAge).ToList();
        }

        public void AddGame(Game game)
        {
            this.Games.Add(game);
            this.SaveChanges();
        }

        public void RemoveGame(Game game) 
        {
            var games = this.Games.Where(x => x.Name == game.Name);
           foreach(var g in games)
            {
                this.Remove(g); 
            }
            this.SaveChanges();
        }

        public void UpdateMinimumAge(Game game, int minimumAge)
        {
            var games = this.Games.Where(x => x.Name == game.Name);
            foreach (var g in games)
            {
                g.MinimumAge = minimumAge;

            }
            this.SaveChanges();
        }


        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
            this.SaveChanges();
        }
        public IEnumerable<PlayerHighScore> GetOrderedHighScores()
        {
            return this.PlayerHighScores.OrderBy(x => x.HighScore);

        }
        //Include מאפשר לאחזר רשומות מקושרות
        public IEnumerable<PlayerHighScore> GetOrderedHighScoresWithPlayerDetails()
        {
            return this.PlayerHighScores.OrderBy(x => x.HighScore).Include(x=>x.Player);

        }

        //אם צריך רשומות מקושרות ברמה נוספת
        //נשתמש בthenInclude
        public IEnumerable<Player> GetPlayerDetails()
        {
         //החזרת השחקנים עם אוסף התוצאות שלהם ולכל תוצאה החזר גם את נתוני המשחקים המקושרים   
            return this.Players.Include(x => x.PlayerHighScores).ThenInclude(x => x.Game.PlayerHighScores);
        }

        public IEnumerable<Game> GamesByScore()
        {
            return this.Games.AsNoTracking().OrderByDescending(x => x.PlayerHighScores.Max(x => x.HighScore)).Include(x => x.PlayerHighScores);
        }
        public void AddPlayer2(Player player)
        {
            this.Entry(player).State=EntityState.Added;
            //this.Entry(player).State= EntityState.Modified;
            //this.Entry(player).State=EntityState.Deleted;
            this.SaveChanges();
        }
        
    }

}
