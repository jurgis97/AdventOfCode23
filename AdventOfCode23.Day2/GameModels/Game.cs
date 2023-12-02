namespace AdventOfCode23.Day2.GameModels;

public class Game
{
    public int Id { get; set; }
    
    public List<Hand> Hands { get; set; } = new List<Hand>(); }