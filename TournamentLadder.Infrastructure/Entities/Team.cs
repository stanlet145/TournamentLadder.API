namespace TournamentLadder.Infrastructure.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; }
    public  List<Member> Members { get; set; }
}