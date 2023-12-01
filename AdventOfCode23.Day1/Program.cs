namespace AdventOfCode23.Day1;

public abstract class Program
{
    public static void Main()
    {
        var day1 = new Day1();
        
        var input = File.ReadAllLines("../../../../AdventOfCode23.Day1/Data/TaskInput.txt");
        var result = day1.CalculateCalibrationValue(input);

        Console.WriteLine($"[Part 1] Day 1 Result: {result}");
    }
}