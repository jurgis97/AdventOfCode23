namespace AdventOfCode23.Day3.Test;

[TestClass]
public class Day3Test
{
    private const string DataFilesRoot = "../../../../AdventOfCode23.Day3/Data";
    
    [TestMethod]
    public void GetSum_Example1Input_Returns4361()
    {
        var input = File.ReadAllLines($"{DataFilesRoot}/Example1.txt");
        var day3 = new Day3();
        
        var result = day3.GetSum(input);
        Assert.AreEqual(4361, result);
    }
    
    [TestMethod]
    [DataRow(".106*643.", 106+643)]
    [DataRow(".50", 0)]
    public void GetSum_CustomData_ReturnsExpectedResult(string input, int expectedResult)
    {
        var lines = input.Split(Environment.NewLine);
        var day3 = new Day3();
        
        var result = day3.GetSum(lines);
        Assert.AreEqual(expectedResult, result);
    }
}