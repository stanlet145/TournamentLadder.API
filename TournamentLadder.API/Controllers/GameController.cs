using Microsoft.AspNetCore.Mvc;
using TournamentLadder.Core.DTO;
using TournamentLadder.Core.Service.Game;

namespace TournamentLadder.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewGame([FromBody] GameDto gameDto)
    {
        await _gameService.AddNewGame(gameDto);
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _gameService.GetAllGames());
    }
}