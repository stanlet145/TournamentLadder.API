using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Core.DTO;

public class GameResponseDto
{
    public Dictionary<Team, int> TeamScores { get; set; }

    public GameResponseDto(Dictionary<Team, int> teamScores)
    {
        TeamScores = teamScores;
    }
}