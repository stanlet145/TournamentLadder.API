namespace TournamentLadder.Infrastructure.Entities;

public class Game : BaseEntity
{
    public Dictionary<Team, int> TeamScore { get; set; }
    public Team GameWinner { get; set; }
}