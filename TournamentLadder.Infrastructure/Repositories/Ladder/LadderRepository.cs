using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Infrastructure.Repositories;

public class LadderRepository : ILadderRepository
{
    public Task<IEnumerable<Ladder>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Ladder> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Ladder entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Ladder entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}