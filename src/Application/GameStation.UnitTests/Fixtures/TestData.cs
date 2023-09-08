namespace GameStation.UnitTests.Fixtures;

public static class TestData
{
    public static IEnumerable<object[]> GetInvalidNumberOfPlayersForTwoPlayerRockPaperScissor()
    {
        yield return new object[]
        {
            GetRockPaperScissorPlayer(), 
            GetRockPaperScissorPlayer(name:"Player2"),
            GetRockPaperScissorPlayer(name:"Player3"),
        };
    }

    public static IEnumerable<object[]> GetInvalidTwoPlayerRockPaperScissor()
    {
        yield return new object[]
        {
            GetRockPaperScissorPlayer(options: RockPaperScissorOptions.Paper),
            new TestPlayer
            {
                Name = "Player2",
                PlayerType = PlayerType.Human,
            },
        };

        yield return new object[]
        {
            new TestPlayer
            {
                Name = "Player2",
                PlayerType = PlayerType.Computer,
            },
            GetRockPaperScissorPlayer(playerType: PlayerType.Computer, options: RockPaperScissorOptions.Paper),
        };
    }

    public static IEnumerable<object[]> GetMatchingCurrentHandPlayers()
    {
        yield return new object[]
        {
            GetRockPaperScissorPlayer(options: RockPaperScissorOptions.Rock),
            GetRockPaperScissorPlayer("Player2", options: RockPaperScissorOptions.Rock),
        };

        yield return new object[]
        {
            GetRockPaperScissorPlayer(playerType: PlayerType.Computer, options: RockPaperScissorOptions.Paper),
            GetRockPaperScissorPlayer("Player2", PlayerType.Computer, RockPaperScissorOptions.Paper),
        };

        yield return new object[]
        {
            GetRockPaperScissorPlayer(options: RockPaperScissorOptions.Scissors),
            GetRockPaperScissorPlayer("Player2", PlayerType.Computer, RockPaperScissorOptions.Scissors),
        };
    }

    public static RockPaperScissorPlayer GetRockPaperScissorPlayer(string name = "Player1",
        PlayerType playerType = PlayerType.Human, RockPaperScissorOptions options = RockPaperScissorOptions.Rock)
        => new()
        {
            Name = name,
            PlayerType = playerType,
            CurrentHand = options
        };
}