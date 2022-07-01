using TournamentLadder.Core.DTO;

namespace TournamentLadder.Core.Service.Mapper;

public interface IGameMapper
{
    Infrastructure.Entities.Game SerializeGame(GameDto dto);
    GameDto DeserializeGame(Infrastructure.Entities.Game game);
}