namespace GameStation.Interfaces;

public interface IGame
{
    IEnumerable<IPlayer> Play(List<IPlayer> players, IGameRules gameRules);
}