using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
    public Task<IEnumerable<Member>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Member> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Member entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Member entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}