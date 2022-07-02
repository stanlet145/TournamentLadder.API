using TournamentLadder.Core.DTO;
using TournamentLadder.Core.Service.Mapper;
using TournamentLadder.Infrastructure.Entities;
using TournamentLadder.Infrastructure.Repositories;

namespace TournamentLadder.Core.Service.Tournament;

public class TournamentService : ITournamentService
{
    private readonly ITournamentRepository _tournamentRepository;
    private readonly IGameMapper _gameMapper;

    public TournamentService(ITournamentRepository tournamentRepository, IGameMapper gameMapper)
    {
        _tournamentRepository = tournamentRepository;
        _gameMapper = gameMapper;
    }

    public async Task<IEnumerable<TournamentResponseDto>> GetAllTournaments()
    {
        var tournaments = await _tournamentRepository.GetAll();
        return tournaments.Select(BuildTournamentDto);
    }

    public async Task<IEnumerable<TournamentResponseDto>> GetAllActiveTournaments()
    {
        var tournaments =  await _tournamentRepository.GetAllActiveTournaments();
        return tournaments.Select(BuildTournamentDto);
    }

    public async Task AddNewTournament(TournamentResponseDto dto)
    {
        await _tournamentRepository.Add(BuildTournament(dto));
    }

    public async Task UpdateTournament(TournamentResponseDto dto)
    {
        await _tournamentRepository.Update(BuildTournament(dto));
    }

    public async Task DeleteTournamentById(int id)
    {
        await _tournamentRepository.DeleteById(id);
    }

    private TournamentResponseDto BuildTournamentDto(Infrastructure.Entities.Tournament tournament)
    {
        return new TournamentResponseDto(tournament.TournamentName, tournament.TournamentStart,
            tournament.TournamentEnd, tournament.TournamentTeams, Map(tournament.Ladder));
    }

    private Infrastructure.Entities.Tournament BuildTournament(TournamentResponseDto dto)
    {
        return new Infrastructure.Entities.Tournament()
        {
            TournamentName = dto.TournamentName,
            TournamentStart = dto.TournamentStart,
            TournamentEnd = dto.TournamentEnd,
            TournamentTeams = dto.TournamentTeams,
            Ladder = Map(dto.Ladder)
        };
    }

    private Ladder Map(LadderDto ladderDto)
    {
        var entity = new Ladder()
        {
            Games = MapGames(ladderDto.GameDtos)
        };
        return entity;
    }

    private List<Infrastructure.Entities.Game> MapGames(IEnumerable<GameDto> gameDtos)
    {
        return gameDtos.Select(gameDto => _gameMapper.SerializeGame(gameDto)).ToList();
    }

    private LadderDto Map(Ladder entity)
    {
        var dto = new LadderDto
        {
            GameDtos = MapGames(entity.Games)
        };
        return dto;
    }

    private List<GameDto> MapGames(IEnumerable<Infrastructure.Entities.Game> games)
    {
        return games.Select(entity => _gameMapper.DeserializeGame(entity)).ToList();
    }
}