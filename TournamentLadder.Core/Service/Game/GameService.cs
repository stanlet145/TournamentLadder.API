using Newtonsoft.Json;
using TournamentLadder.Core.DTO;
using TournamentLadder.Infrastructure.Entities;
using TournamentLadder.Infrastructure.Repositories;

namespace TournamentLadder.Core.Service.Game;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<IEnumerable<GameResponseDto>> GetAllGames()
    {
        var games = await _gameRepository.GetAll();
        return games.Select(
            x => new GameResponseDto(JsonConvert.DeserializeObject<Dictionary<Team, int>>(x.TeamScores)));
    }

    public async Task AddNewGame(GameResponseDto dto)
    {
        await _gameRepository.Add(BuildGame(dto.TeamScores));
    }

    private static Infrastructure.Entities.Game BuildGame(Dictionary<Team, int> gameScores)
    {
        var game = new Infrastructure.Entities.Game
        {
            TeamScores = JsonConvert.SerializeObject(gameScores, Formatting.Indented)
        };
        return game;
    }
}