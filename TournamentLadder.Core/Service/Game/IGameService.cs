using TournamentLadder.Core.DTO;

namespace TournamentLadder.Core.Service.Game;

public interface IGameService
{
    Task<IEnumerable<GameDto>> GetAllGames();
    
    Task AddNewGame(GameDto dto);
    
}