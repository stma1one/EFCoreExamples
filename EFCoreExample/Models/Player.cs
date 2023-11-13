using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Models;

[Table("Player")]
public partial class Player
{
    [Key]
    public int PlayerId { get; set; }

    [StringLength(20)]
    public string Name { get; set; } = null!;

    public int BirthYear { get; set; }

    [InverseProperty("Player")]
    public virtual ICollection<PlayerHighScore> PlayerHighScores { get; set; } = new List<PlayerHighScore>();
}
