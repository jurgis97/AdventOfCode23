namespace AdventOfCode23.Day2.GameModels;

public class Hand
{
    public IList<Draw> Draws { get; set; } = new List<Draw>();
}