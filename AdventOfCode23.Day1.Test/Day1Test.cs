namespace AdventOfCode23.Day1.Test;

[TestClass]
public class Day1Test
{
    [TestMethod]
    public void CalculateCalibrationValue_1abc2_Returns12()
    {
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue("1abc2");
        Assert.AreEqual(12, result);
    }
    
    [TestMethod]
    public void CalculateCalibrationValue_pqr3stu8vwx_Returns38()
    {
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue("pqr3stu8vwx");
        Assert.AreEqual(38, result);
    }
    
    [TestMethod]
    public void CalculateCalibrationValue_a1b2c3d4e5f_Returns15()
    {
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue("a1b2c3d4e5f");
        Assert.AreEqual(15, result);
    }
    
    [TestMethod]
    public void CalculateCalibrationValue_treb7uchet_Returns77()
    {
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue("treb7uchet");
        Assert.AreEqual(77, result);
    }
    
    [TestMethod]
    public void CalculateCalibrationValue_ExampleFile_Returns142()
    {
        var input = File.ReadAllLines("../../../../AdventOfCode23.Day1/Data/Example.txt");
        
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue(input);
        Assert.AreEqual(142, result);
    }
    
    [TestMethod]
    public void CalculateCalibrationValue_TaskInputPartOne_Returns56506()
    {
        var input = File.ReadAllLines("../../../../AdventOfCode23.Day1/Data/TaskInput.txt");
        
        var day1 = new Day1();
        var result = day1.CalculateCalibrationValue(input);
        Assert.AreEqual(56506, result);
    }
}