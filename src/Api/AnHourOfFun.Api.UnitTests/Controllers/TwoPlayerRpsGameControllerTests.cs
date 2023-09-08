namespace AnHourOfFun.Api.UnitTests.Controllers;

public class TwoPlayerRpsGameControllerTests
{
    [Fact]
    public void Play_WhenCalledWrongly_ThrowsExceptionWithExceptionLogged()
    {
        var logger = new Mock<ILogger<TwoPlayerRpsGameController>>();
        var game = new Mock<IGame>();
        game.Setup(g => g.Play(It.IsAny<List<IPlayer>>(),
            It.IsAny<IGameRules>())).Throws<ArgumentException>();
        var sut = GetTwoPlayerRpsGameController(game, logger);
        var players = new List<RockPaperScissorPlayer>();

        Assert.Throws<ArgumentException>(() => sut.Play(players));
        logger.Verify(x => x.Log(
            LogLevel.Error, It.IsAny<EventId>(),
            It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once());
    }

    [Theory]
    [InlineData(RockPaperScissorOptions.Rock, RockPaperScissorOptions.Scissors,
        PlayerType.Human, PlayerType.Human)]
    [InlineData(RockPaperScissorOptions.Paper, RockPaperScissorOptions.Rock,
        PlayerType.Computer, PlayerType.Computer)]
    [InlineData(RockPaperScissorOptions.Scissors, RockPaperScissorOptions.Paper,
        PlayerType.Human, PlayerType.Computer)]
    [InlineData(RockPaperScissorOptions.Paper, RockPaperScissorOptions.Scissors,
        PlayerType.Computer, PlayerType.Human)]
    [InlineData(RockPaperScissorOptions.Scissors, RockPaperScissorOptions.Rock,
        PlayerType.Human, PlayerType.Computer)]
    public void Play_WhenCalledWithPlayersValidPlayers_ReturnOKWithIEnumerationOfPlayers
    (RockPaperScissorOptions option1, RockPaperScissorOptions option2, PlayerType playerType1,
        PlayerType playerType2)
    {
        var game = new Mock<IGame>();
        var sut = GetTwoPlayerRpsGameController(game);

        var player1 = TestData.GetRockPaperScissorPlayer(playerType: playerType1, options: option1);
        var player2 = TestData.GetRockPaperScissorPlayer(name: "Player2", playerType: playerType2, options: option2);
        var players = new List<RockPaperScissorPlayer>()
        {
            player1, player2
        };

        var actionResult = sut.Play(players);

        var ok = actionResult.Result as OkObjectResult;
        Assert.Equal(ok?.StatusCode, StatusCodes.Status200OK);
    }

    private TwoPlayerRpsGameController GetTwoPlayerRpsGameController
        (IMock<IGame> game, IMock<ILogger<TwoPlayerRpsGameController>>? logger = null)
    {
        logger ??= new Mock<ILogger<TwoPlayerRpsGameController>>();
        var gameRules = new Mock<IGameRules>();
        var sut = new TwoPlayerRpsGameController(logger.Object, game.Object, gameRules.Object);
        return sut;
    }
}