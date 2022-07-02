using FluentAssertions;
using TournamentLadder.Core.DTO;
using TournamentLadder.Core.Service.Mapper;
using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Tests.Tests;

public class GameMapperTest
{
    [Fact]
    public Task Deserialize_ShouldReturnGameDto()
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
        return Task.CompletedTask;
    }

    [Fact]
    public Task Serialize_ShouldReturnGame()
    {
        var gameDto = new GameDto(new Dictionary<string, int>()
        {
            { "TeamOne", 2 },
            { "TeamTwo", 1 }
        });

        var gameMapper = new GameMapper();
        var result = gameMapper.SerializeGame(gameDto);

        result.TeamScores.Should().Contain("TeamOne");
        result.TeamScores.Should().Contain("TeamTwo");
        return Task.CompletedTask;
    }
}