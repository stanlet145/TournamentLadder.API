using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    public Task<IEnumerable<Team>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Team> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Team entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Team entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}