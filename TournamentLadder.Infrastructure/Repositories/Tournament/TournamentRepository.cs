using Microsoft.EntityFrameworkCore;
using TournamentLadder.Infrastructure.Context;
using TournamentLadder.Infrastructure.Entities;
using TournamentLadder.Infrastructure.Exceptions;

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

    public async Task<Tournament> GetById(int id)
    {
        var tournament = await _mainContext.Tournament.SingleOrDefaultAsync(x => x.Id == id);
        if (tournament != null)
        {
            return tournament;
        }

        throw new EntityNotFoundException();
    }

    public async Task Add(Tournament entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task Update(Tournament entity)
    {
        var tournamentToUpdate = await _mainContext.Tournament.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (tournamentToUpdate != null)
        {
            tournamentToUpdate.Ladder = entity.Ladder;
            tournamentToUpdate.TournamentName = entity.TournamentName;
            tournamentToUpdate.TournamentTeams = entity.TournamentTeams;
            tournamentToUpdate.TournamentStart = entity.TournamentEnd;
            tournamentToUpdate.TournamentEnd = entity.TournamentEnd;
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            throw new EntityNotFoundException();
        }
    }

    public async Task DeleteById(int id)
    {
        var tournamentToDelete = await _mainContext.Tournament.SingleOrDefaultAsync(x => x.Id == id);
        if (tournamentToDelete != null)
        {
            _mainContext.Tournament.Remove(tournamentToDelete);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            throw new EntityNotFoundException();
        }
    }
}