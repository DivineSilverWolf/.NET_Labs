using Lab1.Color;
using Microsoft.AspNetCore.Mvc;

namespace Lab6_MarkWeb.Controllers;

[ApiController]
public class GameController : ControllerBase
{
    [Route("getcolor")]
    [HttpGet]
    public async Task<Color> GetColor()
    {
    //    await ResourceLock.WaitForResourceAsync();
        return await Task.FromResult(ElonStats.Color);
    }
}