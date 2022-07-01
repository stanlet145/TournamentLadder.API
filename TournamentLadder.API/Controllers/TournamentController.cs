using Microsoft.AspNetCore.Mvc;
using TournamentLadder.Core.DTO;
using TournamentLadder.Core.Service.Tournament;

namespace TournamentLadder.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TournamentController : ControllerBase
{
    private readonly ITournamentService _tournamentService;

    public TournamentController(ITournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewGame([FromBody] TournamentResponseDto tournament)
    {
        await _tournamentService.AddNewTournament(tournament);
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _tournamentService.GetAllTournaments());
    }

    [HttpDelete("DeleteTournamentById")]
    public async Task<IActionResult> DeleteTournamentById([FromQuery(Name = "id")] int id)
    {
        await _tournamentService.DeleteTournamentById(id);
        return NoContent();
    }

    [HttpPost("GetAll")]
    public async Task<IActionResult> UpdateTournament([FromBody] TournamentResponseDto tournament)
    {
        await _tournamentService.UpdateTournament(tournament);
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllActiveTournaments([FromBody] TournamentResponseDto tournament)
    {
        return Ok(await _tournamentService.GetAllTournaments());
    }
}