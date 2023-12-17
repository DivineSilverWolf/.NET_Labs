namespace Lab5_MarkWeb.csproj.Controllers;

using Lab1.card;
using Lab1.Strategy.ParentStrategy;

using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IStrategy _elonCardStrategy;

    public GameController(IStrategy elonCardStrategy)
    {
        _elonCardStrategy = elonCardStrategy;
    }

    [HttpPost("getchoice")]
    public IActionResult GetChoice([FromBody] List<Card> cards)
    {
        var elonChoice = _elonCardStrategy.ReturnNumberCard(cards);
        return Ok(elonChoice);
    }
}