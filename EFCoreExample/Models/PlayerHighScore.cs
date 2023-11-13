using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Models;

[PrimaryKey("GameId", "PlayerId")]
public partial class PlayerHighScore
{
    [Key]
    public int GameId { get; set; }

    [Key]
    public int PlayerId { get; set; }

    public int HighScore { get; set; }

    [ForeignKey("GameId")]
    [InverseProperty("PlayerHighScores")]
    public virtual Game Game { get; set; } = null!;

    [ForeignKey("PlayerId")]
    [InverseProperty("PlayerHighScores")]
    public virtual Player Player { get; set; } = null!;
}
