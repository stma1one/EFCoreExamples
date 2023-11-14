using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
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

        
    }

}
