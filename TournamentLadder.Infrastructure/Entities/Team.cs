namespace TournamentLadder.Infrastructure.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; }
    public Tournament Tournament;
    public  IEnumerable<Member> Members { get; set; }
}