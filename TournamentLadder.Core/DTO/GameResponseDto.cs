using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Core.DTO;

public class GameResponseDto
{
    public Dictionary<string, int> TeamNameScoreDictionary { get; set; }

    public GameResponseDto(Dictionary<string, int> teamNameScoreDictionary)
    {
        TeamNameScoreDictionary = teamNameScoreDictionary;
    }
}