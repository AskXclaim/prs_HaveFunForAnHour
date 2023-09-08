namespace AnHourOfFun.Api.UnitTests.Fixtures;

public static class TestData
{
    public static RockPaperScissorPlayer GetRockPaperScissorPlayer(string name = "Player1",
        PlayerType playerType = PlayerType.Human, RockPaperScissorOptions options = RockPaperScissorOptions.Rock)
        => new()
        {
            Name = name,
            PlayerType = playerType,
            CurrentHand = options
        };
}