namespace GameStation.Interfaces;

public interface IPlayer
{
    public string Name { get; set; }
    public PlayerType PlayerType { get; set; }
    public int Score { get; set; }
}