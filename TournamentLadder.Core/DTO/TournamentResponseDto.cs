using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Core.DTO;

public class TournamentResponseDto
{
    public string TournamentName { get; set; }
    public DateTime TournamentStart { get; set; }
    public DateTime TournamentEnd { get; set; }
    public List<Team> TournamentTeams { get; set; }
    public Ladder Ladder { get; set; }

    public TournamentResponseDto(string tournamentName, DateTime tournamentStart, DateTime tournamentEnd, List<Team> tournamentTeams, Ladder ladder)
    {
        TournamentName = tournamentName;
        TournamentStart = tournamentStart;
        TournamentEnd = tournamentEnd;
        TournamentTeams = tournamentTeams;
        Ladder = ladder;
    }
}