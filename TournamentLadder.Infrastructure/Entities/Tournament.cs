namespace TournamentLadder.Infrastructure.Entities;

public class Tournament : BaseEntity
{
    public string TournamentName { get; set; }
    public DateTime TournamentStart { get; set; }
    public DateTime TournamentEnd { get; set; }
    public List<Team> TournamentTeams { get; set; }
    public Ladder Ladder { get; set; }
}