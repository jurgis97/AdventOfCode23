namespace AdventOfCode23.Day1;

public class Day1
{
    public int CalculateCalibrationValue(string[] lines)
    {
        var result = 0;
        foreach (var line in lines)
        {
            result += CalculateCalibrationValue(line);
        }

        return result;
    }
    
    public int CalculateCalibrationValue(string lineValue)
    {
        var firstDigit = lineValue.FirstOrDefault(x => int.TryParse(x.ToString(), out _));
        var lastDigit = lineValue.LastOrDefault(x => int.TryParse(x.ToString(), out _));

        return int.Parse($"{firstDigit}{lastDigit}");
    }
}