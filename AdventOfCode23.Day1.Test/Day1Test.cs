namespace AdventOfCode23.Day1.Test;

[TestClass]
public class Day1Test
{
    private const string DataFilesRoot = "../../../../AdventOfCode23.Day1/Data";
    
    [TestMethod]
    [DataRow(0, 12)]
    [DataRow(1, 38)]
    [DataRow(2, 15)]
    [DataRow(3, 77)]
    public void CalculateCalibrationValue_Example1AsSingleLines_ReturnsExpectedInt(int lineIndex, int expected)
    {
        var lines = File.ReadAllLines($"{DataFilesRoot}/Example1.txt");
        var line = lines[lineIndex];
        
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue(line);
        Assert.AreEqual(expected, result, $"Line: {line} | Expected: {expected} | Result: {result}");
    }
    
    [TestMethod]
    [DataRow(0, 29)]
    [DataRow(1, 83)]
    [DataRow(2, 13)]
    [DataRow(3, 24)]
    [DataRow(4, 42)]
    [DataRow(5, 14)]
    [DataRow(6, 76)]
    public void CalculateCalibrationValue_Example2AsSingleLines_ReturnsExpectedInt(int lineIndex, int expected)
    {
        var lines = File.ReadAllLines($"{DataFilesRoot}/Example2.txt");
        var line = lines[lineIndex];
        
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue(line);
        Assert.AreEqual(expected, result, $"Line: {line} | Expected: {expected} | Result: {result}");
    }
    
    [TestMethod]
    [DataRow("foo3twone", 31)]
    public void CalculateCalibrationValue_CustomLines_ReturnsExpectedInt(string line, int expected)
    {
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue(line);
        Assert.AreEqual(expected, result, $"Line: {line} | Expected: {expected} | Result: {result}");
    }
    
    [TestMethod]
    public void CalculateCalibrationValue_ExampleFile_Returns142()
    {
        var input = File.ReadAllLines($"{DataFilesRoot}/Example1.txt");
        
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue(input);
        Assert.AreEqual(142, result);
    }
    
    [TestMethod]
    public void CalculateCalibrationValue_ExampleFile_Returns281()
    {
        var input = File.ReadAllLines($"{DataFilesRoot}/Example2.txt");
        
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue(input);
        Assert.AreEqual(281, result);
    }
    
    [TestMethod]
    public void CalculateCalibrationValue_TaskInputPartOne_Returns56506()
    {
        var input = File.ReadAllLines($"{DataFilesRoot}/TaskInput.txt");
        
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue(input);
        Assert.AreEqual(56506, result);
    }
}