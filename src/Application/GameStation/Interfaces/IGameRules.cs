namespace GameStation.Interfaces;

public interface IGameRules
{
    IEnumerable<IPlayer> Apply(List<IPlayer> players);
}