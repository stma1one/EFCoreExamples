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
        public void AddGame(string name,int minimumAge)
        {
            Game game = new Game() { Name = name, MinimumAge = minimumAge } ;
            this.Games.Add(game);
            this.SaveChanges();

           
        }

        public void RemoveGame(string name) 
        {
            IEnumerable<Game> games = this.Games.Where(x => x.Name == name).AsEnumerable() ;
            if(games != null)
            {
                this.Games.RemoveRange(games);
                this.SaveChanges();
            }
        }
    }
}
