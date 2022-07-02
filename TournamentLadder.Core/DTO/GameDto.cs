using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Core.DTO;

public class GameDto
{
    public Dictionary<string, int> TeamNameScoreDictionary { get; set; }

    public GameDto(Dictionary<string, int> teamNameScoreDictionary)
    {
        TeamNameScoreDictionary = teamNameScoreDictionary;
    }
}