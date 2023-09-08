namespace GameStation.RockPaperScissor;

public class RockPaperScissorPlayer:IPlayer
{
    public string Name { get; set; }
    public PlayerType PlayerType { get; set; }
    public int Score { get; set; }
    public RockPaperScissorOptions CurrentHand { get; set; }
    public PossibleResult Result { get; set; }
}