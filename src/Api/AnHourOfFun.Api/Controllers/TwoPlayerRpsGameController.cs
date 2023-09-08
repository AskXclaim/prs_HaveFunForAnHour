namespace AnHourOfFun.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TwoPlayerRpsGameController : Controller
{
    private readonly ILogger<TwoPlayerRpsGameController> _logger;
    private readonly IGame _game;
    private readonly IGameRules _gameRules;

    public TwoPlayerRpsGameController(ILogger<TwoPlayerRpsGameController> logger,
        IGame game, IGameRules gameRules)
    {
        _logger = logger;
        _game = game;
        _gameRules = gameRules;
    }

    [HttpPost]
    [Route(nameof(Play))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IPlayer>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<RockPaperScissorPlayer>> Play(List<RockPaperScissorPlayer> players)
    {
        try
        {
            var iPlayers = players.Cast<IPlayer>().ToList();
            var result = _game.Play(iPlayers, _gameRules);
            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"An error occurred while calling {nameof(Play)} with parameters;" +
                                        $"{Environment.NewLine}{nameof(players)}:{players}");
            throw;
        }
    }
}