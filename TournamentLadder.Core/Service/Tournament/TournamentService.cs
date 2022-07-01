using TournamentLadder.Core.DTO;
using TournamentLadder.Infrastructure.Repositories;

namespace TournamentLadder.Core.Service.Tournament;

public class TournamentService : ITournamentService
{
    private readonly ITournamentRepository _tournamentRepository;

    public TournamentService(ITournamentRepository tournamentRepository)
    {
        _tournamentRepository = tournamentRepository;
    }
    
    public async Task<IEnumerable<TournamentResponseDto>> GetAllTournaments()
    {
        var games = await _tournamentRepository.GetAll();
        return games.Select(
            x => new TournamentResponseDto(
                x.TournamentName, x.TournamentStart, x.TournamentEnd, x.TournamentTeams, x.Ladder));
    }

    public Task<IEnumerable<TournamentResponseDto>> GetAllActiveTournaments()
    {
        throw new NotImplementedException();
    }

    public async Task AddNewTournament(TournamentResponseDto dto)
    {
        await _tournamentRepository.Add(BuildTournament(dto));
    }

    public Task UpdateTournament(TournamentResponseDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTournamentById(int id)
    {
        throw new NotImplementedException();
    }

    private static Infrastructure.Entities.Tournament BuildTournament(TournamentResponseDto dto)
    {
        return new Infrastructure.Entities.Tournament()
        {
            TournamentName = dto.TournamentName,
            TournamentStart = dto.TournamentStart,
            TournamentEnd = dto.TournamentEnd,
            TournamentTeams = dto.TournamentTeams,
            Ladder = dto.Ladder
        };
    }
}