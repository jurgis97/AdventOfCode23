namespace AdventOfCode23.Day2;

using GameModels;

public class Day2
{
    private readonly BagInformation _bagInformation;

    public Day2(BagInformation bagInformation)
    {
        _bagInformation = bagInformation;
    }

    public int GetGamesPowerSums(IEnumerable<Game> games)
    {
        return games.Sum(GetGamePower);
    }

    public int GetGamePower(Game game)
    {
        var power = 1;

        var minBagValues = new BagInformation();
        foreach (var hand in game.Hands)
        {
            foreach (var draw in hand.Draws)
            {
                if (minBagValues.AvailableBallsForColor.ContainsKey(draw.Color))
                {
                    if (draw.NumberOfCubes > minBagValues.AvailableBallsForColor[draw.Color])
                    {
                        minBagValues.AvailableBallsForColor[draw.Color] = draw.NumberOfCubes;
                    }
                }
                else
                {
                    minBagValues.AvailableBallsForColor.Add(draw.Color, draw.NumberOfCubes);
                }
            }
        }
        
        minBagValues.AvailableBallsForColor.Values.ToList().ForEach(x => power *= x);
        return power;
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