using System.Collections;

namespace TournamentLadder.Infrastructure.Entities;

public class Game : BaseEntity
{
    public string TeamScores { get; set; }
    public Ladder Ladder { get; set; }
}