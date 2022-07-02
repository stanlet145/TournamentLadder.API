using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Infrastructure.Repositories;

public interface ITournamentRepository : IRepository<Tournament>
{
    Task<List<Tournament>> GetAllActiveTournaments();
}