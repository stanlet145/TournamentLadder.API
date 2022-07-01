using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    public Task<IEnumerable<Game>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Game> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Game entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Game entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}