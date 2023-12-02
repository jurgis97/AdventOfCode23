namespace AdventOfCode23.Day1;

public class Day1
{
    public int CalculateCalibrationValue(IEnumerable<string> lines)
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
        var firstDigit = ParseFirstDigit(lineValue);
        var lastDigit = ParseLastDigit(lineValue);

        return int.Parse($"{firstDigit}{lastDigit}");
    }
    
    private static int ParseFirstDigit(string lineValue)
    {
        var reg = NumberString.SingleDigitNumbersPatternWithLookahead;
        var match = reg.Matches(lineValue).First();

        return NumberString.ParseToInt(match, lineValue);
    }
    
    private static int ParseLastDigit(string lineValue)
    {
        var reg = NumberString.SingleDigitNumbersPatternWithLookahead;
        var match = reg.Matches(lineValue).Last();

        return NumberString.ParseToInt(match, lineValue);
    }
}