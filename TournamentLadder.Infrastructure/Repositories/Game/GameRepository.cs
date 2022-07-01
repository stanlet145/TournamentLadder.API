using Microsoft.EntityFrameworkCore;
using TournamentLadder.Infrastructure.Context;
using TournamentLadder.Infrastructure.Entities;
using TournamentLadder.Infrastructure.Exceptions;

namespace TournamentLadder.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly MainContext _mainContext;

    public GameRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<IEnumerable<Game>> GetAll()
    {
        return await _mainContext.Game.ToListAsync();
    }

    public async Task<Game> GetById(int id)
    {
        var game = await _mainContext.Game.SingleOrDefaultAsync(x => x.Id == id);
        if (game != null)
        {
            return game;
        }

        throw new EntityNotFoundException();
    }

    public async Task Add(Game entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task Update(Game entity)
    {
        var gameToUpdate = await _mainContext.Game.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (gameToUpdate != null)
        {
            gameToUpdate.TeamScores = entity.TeamScores;
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            throw new EntityNotFoundException();
        }
    }

    public async Task DeleteById(int id)
    {
        var gameToDelete = await _mainContext.Game.SingleOrDefaultAsync(x => x.Id == id);
        if (gameToDelete != null)
        {
            _mainContext.Game.Remove(gameToDelete);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            throw new EntityNotFoundException();
        }
    }
}