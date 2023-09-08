namespace GameStation.UnitTests;

public class TwoPlayerRockPaperScissorGameRulesTests
{
    [Fact]
    public void Apply_WhenCalledWithOnePlayer_ThrowsArgumentException()
    {
        var sut = new RockPaperScissorGame();
        var rules = new TwoPlayerRockPaperScissorGameRules();
        var data = new List<IPlayer> {TestData.GetRockPaperScissorPlayer()};

        Assert.Throws<ArgumentException>(() => sut.Play(data, rules));
    }

    [Theory]
    [MemberData(nameof(TestData.GetInvalidNumberOfPlayersForTwoPlayerRockPaperScissor), MemberType = typeof(TestData))]
    public void Apply_WhenCalledWithMoreThanOnePlayer_ThrowsArgumentException(IPlayer player1, IPlayer player2,
        IPlayer player3)
    {
        var sut = new RockPaperScissorGame();
        var rules = new TwoPlayerRockPaperScissorGameRules();
        var data = new List<IPlayer> {player1, player2, player3};

        Assert.Throws<ArgumentException>(() => sut.Play(data, rules));
    }

    [Theory]
    [MemberData(nameof(TestData.GetInvalidTwoPlayerRockPaperScissor), MemberType = typeof(TestData))]
    public void Apply_WhenCalledWithInvalidPlayers_ThrowsArgumentException(IPlayer player1, IPlayer player2)
    {
        var (sut, rules, data) = GetRockPaperScissorGameAndRulesAndData(player1, player2);

        Assert.Throws<ArgumentException>(() => sut.Play(data, rules));
    }

    [Theory]
    [MemberData(nameof(TestData.GetMatchingCurrentHandPlayers), MemberType = typeof(TestData))]
    public void Apply_WhenCalledWithPlayersWithSimilarCurrentHand_CurrentHandForBothPlayersWillBeEqual
        (RockPaperScissorPlayer player1, RockPaperScissorPlayer player2)
    {
        var (sut, rules, data) = GetRockPaperScissorGameAndRulesAndData(player1, player2);

        var result = sut.Play(data, rules).ToList();

        Assert.Equal(ConvertToRockPaperScissorGame(result[0]).CurrentHand,
            ConvertToRockPaperScissorGame(result[1]).CurrentHand);
        Assert.Equal(PossibleResult.Tie, ConvertToRockPaperScissorGame(result[0]).Result);
        Assert.Equal(PossibleResult.Tie, ConvertToRockPaperScissorGame(result[1]).Result);
        Assert.Equal(0, ConvertToRockPaperScissorGame(result[1]).Score);
        Assert.Equal(0, ConvertToRockPaperScissorGame(result[1]).Score);
    }

    [Theory]
    [InlineData(RockPaperScissorOptions.Rock, RockPaperScissorOptions.Scissors,
        PlayerType.Human, PlayerType.Human, 1, PossibleResult.Win)]
    [InlineData(RockPaperScissorOptions.Paper, RockPaperScissorOptions.Rock,
        PlayerType.Computer, PlayerType.Computer, 1, PossibleResult.Win)]
    [InlineData(RockPaperScissorOptions.Scissors, RockPaperScissorOptions.Paper,
        PlayerType.Human, PlayerType.Computer, 1, PossibleResult.Win)]
    [InlineData(RockPaperScissorOptions.Paper, RockPaperScissorOptions.Scissors,
        PlayerType.Computer, PlayerType.Human, 0, PossibleResult.Lose)]
    [InlineData(RockPaperScissorOptions.Scissors, RockPaperScissorOptions.Rock,
        PlayerType.Human, PlayerType.Computer, 0, PossibleResult.Lose)]
    public void
        Apply_WhenCalledWithPlayersWithDisSimilarCurrentHand_CurrentHandForBothPlayersWillNotBeEqualAndScoreForWinWillBeUpdated
        (RockPaperScissorOptions option1, RockPaperScissorOptions option2, PlayerType playerType1,
            PlayerType playerType2, int score, PossibleResult expectedResult)
    {
        var player1 = TestData.GetRockPaperScissorPlayer(playerType: playerType1, options: option1);
        var player2 = TestData.GetRockPaperScissorPlayer(name: "Player2", playerType: playerType2, options: option2);

        var (sut, rules, data) = GetRockPaperScissorGameAndRulesAndData(player1, player2);

        var result = sut.Play(data, rules).ToList();

        Assert.NotEqual(ConvertToRockPaperScissorGame(result[0]).CurrentHand,
            ConvertToRockPaperScissorGame(result[1]).CurrentHand);
        Assert.Equal(score, ConvertToRockPaperScissorGame(result[0]).Score);
        Assert.Equal(expectedResult, ConvertToRockPaperScissorGame(result[0]).Result);
    }

    private (RockPaperScissorGame sut, TwoPlayerRockPaperScissorGameRules rules, List<IPlayer> data)
        GetRockPaperScissorGameAndRulesAndData(IPlayer player1, IPlayer player2)
    {
        var sut = new RockPaperScissorGame();
        var rules = new TwoPlayerRockPaperScissorGameRules();
        var data = new List<IPlayer> {player1, player2};
        return (sut, rules, data);
    }

    private RockPaperScissorPlayer ConvertToRockPaperScissorGame(IPlayer player) =>
        (RockPaperScissorPlayer) player;
}