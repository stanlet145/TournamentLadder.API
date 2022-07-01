namespace TournamentLadder.Infrastructure.Entities;

public class Member : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Nickname { get; set; }
    public Role Role { get; set; }
}