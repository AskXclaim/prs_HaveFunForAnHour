namespace GameStation.UnitTests.Fixtures;

public class TestPlayer:IPlayer
{
    public string Name { get; set; }
    public PlayerType PlayerType { get; set; }
    public int Score { get; set; }
}