using Newtonsoft.Json;
using TournamentLadder.Core.DTO;
using TournamentLadder.Infrastructure.Repositories;

namespace TournamentLadder.Core.Service.Game;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<IEnumerable<GameDto>> GetAllGames()
    {
        var games = await _gameRepository.GetAll();
        return games.Select(
            x => new GameDto(JsonConvert.DeserializeObject<Dictionary<string, int>>(x.TeamScores)));
    }

    public async Task AddNewGame(GameDto dto)
    {
        await _gameRepository.Add(BuildGame(dto.TeamNameScoreDictionary));
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