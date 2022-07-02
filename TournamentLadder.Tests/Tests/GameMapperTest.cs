using FluentAssertions;
using TournamentLadder.Core.Service.Mapper;
using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Tests.Tests;

public class GameMapperTest
{
    [Fact]
    public async Task T()
    {
        var game = new Game
        {
            TeamScores = @"{
                           'TeamOne': 2,
                            'TeamTwo': 1
                            }",
            Ladder = new Ladder()
        };
        var gameMapper = new GameMapper();
        var result = gameMapper.DeserializeGame(game);

        result.TeamNameScoreDictionary.Should().NotBeNull();
        result.TeamNameScoreDictionary.Keys.First().Should().Be("TeamOne");
    }
}