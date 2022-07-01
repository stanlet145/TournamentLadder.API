using TournamentLadder.Core.DTO;

namespace TournamentLadder.Core.Service.Game;

public interface IGameService
{
    Task<IEnumerable<GameResponseDto>> GetAllGames();
    
    Task AddNewGame(GameResponseDto dto);
    
}