using Newtonsoft.Json;
using TournamentLadder.Core.DTO;

namespace TournamentLadder.Core.Service.Mapper;

public class GameMapper : IGameMapper
{
    public Infrastructure.Entities.Game SerializeGame(GameDto dto)
    {
        return BuildGame(dto.TeamNameScoreDictionary);
    }

    public GameDto DeserializeGame(Infrastructure.Entities.Game game)
    {
        return new GameDto(JsonConvert.DeserializeObject<Dictionary<string, int>>(game.TeamScores));
    }

    private static Infrastructure.Entities.Game BuildGame(Dictionary<string, int> gameScores)
    {
        var game = new Infrastructure.Entities.Game
        {
            TeamScores = JsonConvert.SerializeObject(gameScores, Formatting.Indented)
        };
        return game;
    }
}