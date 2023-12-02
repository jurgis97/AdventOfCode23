using AdventOfCode23.Day2;
using AdventOfCode23.Day2.GameModels;

BagInformation example1BagInformation = new ()
{
    AvailableBallsForColor = new Dictionary<Color, int>
    {
        {Color.Red, 12},
        {Color.Green, 13},
        {Color.Blue, 14}
    }
};

var day2 = new Day2(example1BagInformation);
        
var input = File.ReadAllLines("../../../../AdventOfCode23.Day2/Data/TaskInput.txt");
var games = input.Select(GameParser.ParseGameFromLine);
var result = day2.GetSumOfPossibleGamesIds(games);

Console.WriteLine($"Day 2 Part 1 Result: {result}");

var gamesPowerSums = day2.GetGamesPowerSums(games);
Console.WriteLine($"Day 2 Part 2 Result: {gamesPowerSums}");