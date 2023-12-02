namespace AdventOfCode23.Day2;

using GameModels;

public class Day2
{
    private readonly BagInformation _bagInformation;

    public Day2(BagInformation bagInformation)
    {
        _bagInformation = bagInformation;
    }

    public int GetSumOfPossibleGamesIds(IEnumerable<Game> games)
    {
        var sum = 0;
        foreach (var game in games)
        {
            if (IsGamePossible(game))
            {
                sum+= game.Id;
            }
        }

        return sum;
    }
    
    public bool IsGamePossible(Game game)
    {
        foreach (var color in _bagInformation.AvailableBallsForColor.Keys)
        {
            if (game.Hands.Any(x =>
                    x.Draws.Any(y =>
                        y.Color == color
                        && y.NumberOfCubes > _bagInformation.AvailableBallsForColor[color])))
            {
                return false;
            }
        }
        
        return true;
    }
}