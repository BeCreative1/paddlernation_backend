using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Domain.DTOs.PaddleBoard;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaddleBoardsController : ControllerBase
{
    private readonly IPaddleBoardLogic PaddleBoardLogic;

    public PaddleBoardsController(IPaddleBoardLogic paddleBoardLogic)
    {
        PaddleBoardLogic = paddleBoardLogic;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPaddleBoardsAsync([FromQuery] string dates)
    {
        try
        {
            IEnumerable<PaddleBoardDto> paddleBoards = await PaddleBoardLogic.GetAllPaddleBoardsAsync(dates);
            return Ok(paddleBoards);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}