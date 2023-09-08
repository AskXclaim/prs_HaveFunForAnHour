namespace GameStation.RockPaperScissor;

public class RockPaperScissorGame : IGame
{
    public IEnumerable<IPlayer> Play(List<IPlayer> players, IGameRules gameRules) =>
        gameRules.Apply(players);
}