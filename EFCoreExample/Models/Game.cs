using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Models;

[Table("Game")]
public partial class Game
{
    [Key]
    public int GameId { get; set; }

    [StringLength(20)]
    public string Name { get; set; } = null!;

    public int MinimumAge { get; set; }

    [InverseProperty("Game")]
    public virtual ICollection<PlayerHighScore> PlayerHighScores { get; set; } = new List<PlayerHighScore>();
}
