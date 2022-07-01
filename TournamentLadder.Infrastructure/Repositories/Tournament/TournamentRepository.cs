using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Infrastructure.Repositories;

public class TournamentRepository : ITournamentRepository
{
    public Task<IEnumerable<Tournament>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Tournament> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Tournament entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Tournament entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}