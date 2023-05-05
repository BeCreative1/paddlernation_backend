using Application.LogicInterfaces;
using Domain;
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
    public async Task<IActionResult> GetAllPaddleBoardsAsync([FromQuery] string date)
    {
        try
        {
            IEnumerable<PaddleBoard> paddleBoards = await PaddleBoardLogic.GetAllPaddleBoardsAsync();
            return Ok(paddleBoards);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}