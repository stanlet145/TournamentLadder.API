using TournamentLadder.Core.DTO;

namespace TournamentLadder.Core.Service.Tournament;

public interface ITournamentService
{
    Task<IEnumerable<TournamentResponseDto>> GetAllTournaments();

    Task<IEnumerable<TournamentResponseDto>> GetAllActiveTournaments();

    Task AddNewTournament(TournamentResponseDto dto);

    Task UpdateTournament(TournamentResponseDto dto);
    
    Task DeleteTournamentById(int id);
}