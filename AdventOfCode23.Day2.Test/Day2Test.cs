namespace AdventOfCode23.Day2.Test;

using GameModels;

[TestClass]
public class Day2Test
{
    private const string DataFilesRoot = "../../../../AdventOfCode23.Day2/Data";
    private static readonly BagInformation Example1BagInformation = new ()
    {
        AvailableBallsForColor = new Dictionary<Color, int>
        {
            {Color.Red, 12},
            {Color.Green, 13},
            {Color.Blue, 14}
        }
    };
    
    [TestMethod]
    [DataRow(0, true)]
    [DataRow(1, true)]
    [DataRow(2, false)]
    [DataRow(3, false)]
    [DataRow(4, true)]
    public void IsGamePossible_FromExampleFile_ReturnsGame(int lineIndex, bool expected)
    {
        var lines = File.ReadAllLines($"{DataFilesRoot}/Example1.txt");
        var line = lines[lineIndex];
        
        var day2 = new Day2(Example1BagInformation);
        var game = GameParser.ParseGameFromLine(line);
        var isGamePossible = day2.IsGamePossible(game);
        
        Assert.AreEqual(expected, isGamePossible, $"Line: {line} | Expected: {expected} | Result: {isGamePossible}");
    }
    
    [TestMethod]
    public void GetSumOfPossibleGamesIds_FromExampleFile_Returns4()
    {
        var lines = File.ReadAllLines($"{DataFilesRoot}/Example1.txt");
        
        var day2 = new Day2(Example1BagInformation);
        var games = lines.Select(GameParser.ParseGameFromLine);
        var sum = day2.GetSumOfPossibleGamesIds(games);
        
        Assert.AreEqual(8, sum);
    }
    
    [TestMethod]
    [DataRow(0, 48)]
    [DataRow(1, 12)]
    [DataRow(2, 1560)]
    [DataRow(3, 630)]
    [DataRow(4, 36)]
    public void GetGamePower_FromExampleFile_ReturnsGame(int lineIndex, int expected)
    {
        var lines = File.ReadAllLines($"{DataFilesRoot}/Example1.txt");
        var line = lines[lineIndex];
        
        var day2 = new Day2(Example1BagInformation);
        var game = GameParser.ParseGameFromLine(line);
        var gamePower = day2.GetGamePower(game);
        
        Assert.AreEqual(expected, gamePower, $"Line: {line} | Expected: {expected} | Result: {gamePower}");
    }
    
    [TestMethod]
    public void GetGamesPowerSums_FromExampleFile_Returns2286()
    {
        var lines = File.ReadAllLines($"{DataFilesRoot}/Example1.txt");
        
        var day2 = new Day2(Example1BagInformation);
        var games = lines.Select(GameParser.ParseGameFromLine);
        var sum = day2.GetGamesPowerSums(games);
        
        Assert.AreEqual(2286, sum);
    }
}