using Microsoft.EntityFrameworkCore;
using TournamentLadder.Infrastructure.Context;
using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Infrastructure.Repositories;

public class TournamentRepository : ITournamentRepository
{
    
    private readonly MainContext _mainContext;

    public TournamentRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    public async Task<IEnumerable<Tournament>> GetAll()
    {
        return await _mainContext.Tournament.ToListAsync();
    }

    public Task<Tournament> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Add(Tournament entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
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