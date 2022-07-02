using FluentAssertions;
using Moq;
using TournamentLadder.Core.Service.Mapper;
using TournamentLadder.Core.Service.Tournament;
using TournamentLadder.Infrastructure.Entities;
using TournamentLadder.Infrastructure.Repositories;

namespace TournamentLadder.Tests.Tests;

public class TournamentServiceTest
{
    [Fact]
    public async Task GetT()
    {
        var tournaments = new List<Tournament>()
        {
            new()
            {
                TournamentName = "ArenaCup",
                TournamentStart = new DateTime(2022, 7, 1),
                TournamentEnd = new DateTime(2022, 7, 22),
                TournamentTeams = new List<Team>()
                {
                    new()
                    {
                        Name = "TwoBlasters",
                        Members = new List<Member>()
                        {
                            new()
                            {
                                Name = "Adam",
                                Surname = "Kokos",
                                Nickname = "Kokos",
                                Role = Role.PLAYER
                            },
                            new()
                            {
                                Name = "Tomasz",
                                Surname = "Kowalski",
                                Nickname = "Tomi",
                                Role = Role.PLAYER
                            }
                        }
                    }
                },
                Ladder = new Ladder()
                {
                    Games = new List<Game>()
                    {
                        new()
                        {
                            TeamScores = @"{
                            'teamNameScoreDictionary': {
                            'additionalProp1': 0,
                            'additionalProp2': 0,
                            'additionalProp3': 0
                                 }
                             }"
                        }
                    }
                }
            }
        };

        var tournamentRepository = new Moq.Mock<ITournamentRepository>();
        tournamentRepository.Setup(x => x.GetAllActiveTournaments()).ReturnsAsync(tournaments);
        var tournamentService = new TournamentService(tournamentRepository.Object, Mock.Of<IGameMapper>());
        var result = await tournamentService.GetAllActiveTournaments();

        result.Should().NotBeNull();
        result.First().TournamentName.Should().Be("ArenaCup");
        result.First().TournamentStart.Should().Be(new DateTime(2022, 7, 1));
        result.First().TournamentEnd.Should().Be(new DateTime(2022, 7, 22));
        result.First().TournamentTeams.First().Name.Should().Be("TwoBlasters");
        result.First().Ladder.Should().NotBeNull();
    }
}