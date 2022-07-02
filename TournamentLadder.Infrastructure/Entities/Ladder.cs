namespace TournamentLadder.Infrastructure.Entities;

public class Ladder : BaseEntity
{
    public List<Game> Games { get; set; }

    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
}