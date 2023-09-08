namespace GameStation.RockPaperScissor;

public class TwoPlayerRockPaperScissorGameRules : IGameRules
{
    public IEnumerable<IPlayer> Apply(List<IPlayer> players)
    {
        if (players.Count != 2)
            throw new ArgumentException($"Amount of players supplied needs to be two");

        var rockPaperScissorPlayers = new List<RockPaperScissorPlayer>();
        ConvertToRequiredPlayerType(players, rockPaperScissorPlayers);

        var (player1, player2) = GetRockPaperScissorPlayers(rockPaperScissorPlayers);

        if (player1.CurrentHand == player2.CurrentHand)
        {
            SetPlayers(player1, player2, PossibleResult.Tie, PossibleResult.Tie);

            return GetResult(player1, player2);
        }

        switch (player1.CurrentHand)
        {
            case RockPaperScissorOptions.Rock
                when player2.CurrentHand == RockPaperScissorOptions.Scissors:
                SetPlayers(player1, player2, PossibleResult.Win, PossibleResult.Lose);
                SetScore(player1, player2);
                return GetResult(player1, player2);

            case RockPaperScissorOptions.Paper
                when player2.CurrentHand == RockPaperScissorOptions.Rock:
                SetPlayers(player1, player2, PossibleResult.Win, PossibleResult.Lose);
                SetScore(player1, player2);
                return GetResult(player1, player2);

            case RockPaperScissorOptions.Scissors
                when player2.CurrentHand == RockPaperScissorOptions.Paper:
                SetPlayers(player1, player2, PossibleResult.Win, PossibleResult.Lose);
                SetScore(player1, player2);
                return GetResult(player1, player2);

            default:
                SetPlayers(player1, player2, PossibleResult.Lose, PossibleResult.Win);
                SetScore(player1, player2);
                return GetResult(player1, player2);
        }
    }

    private (RockPaperScissorPlayer player1, RockPaperScissorPlayer player2) GetRockPaperScissorPlayers(
        List<RockPaperScissorPlayer> rockPaperScissorPlayers)
    {
        var player1 = rockPaperScissorPlayers[0];
        var player2 = rockPaperScissorPlayers[1];
        return (player1, player2);
    }

    private void ConvertToRequiredPlayerType(List<IPlayer> players,
        ICollection<RockPaperScissorPlayer> rockPaperScissorPlayers)
    {
        foreach (var player in players)
        {
            try
            {
                rockPaperScissorPlayers.Add((RockPaperScissorPlayer) player);
            }
            catch (Exception)
            {
                throw new ArgumentException($"All players have to be of type {nameof(RockPaperScissorPlayer)}");
            }
        }
    }

    private void SetPlayers(RockPaperScissorPlayer player1, RockPaperScissorPlayer player2,
        PossibleResult value1, PossibleResult value2)
    {
        player1.Result = value1;
        player2.Result = value2;
    }

    private void SetScore(RockPaperScissorPlayer player1, RockPaperScissorPlayer player2)
    {
        if (player1.Result == PossibleResult.Win) player1.Score += 1;

        if (player2.Result == PossibleResult.Win) player2.Score += 1;
    }

    private IEnumerable<IPlayer> GetResult(RockPaperScissorPlayer player1, RockPaperScissorPlayer player2) =>
        new List<RockPaperScissorPlayer>
        {
            player1, player2
        };
}