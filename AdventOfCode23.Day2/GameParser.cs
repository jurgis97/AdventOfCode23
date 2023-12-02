namespace AdventOfCode23.Day2;

using GameModels;

public abstract class GameParser
{
    public static Game ParseGameFromLine(string inputLine)
    {
        var game = new Game();
        
        var split = inputLine.Split(":");
        game.Id = int.Parse(split[0].Replace("Game ", ""));
        
        var handsString = split[1].Split(";");
        game.Hands = ParseHands(handsString);

        return game;
    }

    private static List<Hand> ParseHands(string[] handsString)
    {
        var hands = new List<Hand>();
        foreach (var handString in handsString)
        {
            var hand = new Hand();
            var drawsString = handString.Split(",");
            //parse draws
            hand.Draws = ParseDraws(drawsString);

            hands.Add(hand);
        }

        return hands;
    }

    private static IList<Draw> ParseDraws(string[] drawsString)
    {
        var draws = new List<Draw>();
        foreach (var drawString in drawsString)
        {
            var draw = new Draw();
            var drawSplit = drawString.Split(" ");
            draw.NumberOfCubes = int.Parse(drawSplit[1]);
            draw.Color = (Color) Enum.Parse(typeof(Color), drawSplit[2], true);
            draws.Add(draw);
        }

        return draws;
    }
}