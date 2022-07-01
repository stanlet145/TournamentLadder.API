using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Core.DTO;

public class MemberDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Nickname { get; set; }
    public Role Role { get; set; }
}