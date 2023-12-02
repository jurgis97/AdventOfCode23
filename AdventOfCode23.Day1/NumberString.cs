namespace AdventOfCode23.Day1;

using System.Text.RegularExpressions;

public class NumberString
{
    private static readonly Dictionary<string, int> Numbers = new()
    {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4},
        {"five", 5},
        {"six", 6},
        {"seven", 7},
        {"eight", 8},
        {"nine", 9},
    };
    
    public static readonly Regex SingleDigitNumbersPattern =
        new Regex($@"({Numbers.Keys.Aggregate((x, y) => $"{x}|{y}")}|[1-9])",
            RegexOptions.IgnoreCase);
    
    public static readonly Regex SingleDigitNumbersPatternWithLookahead =
        new Regex($@"(?=({Numbers.Keys.Aggregate((x, y) => $"{x}|{y}")}|[1-9]))",
            RegexOptions.IgnoreCase);
    
    public static int ParseToInt(string stringDigit)
    {
        if (int.TryParse(stringDigit, out var digit))
        {
            return digit;
        }
        
        return Numbers[stringDigit];
    }
    
    public static int ParseToInt(Match match, string input)
    {
        var stringDigit = SingleDigitNumbersPattern.Match(input.Substring(match.Index)).Value;
        return ParseToInt(stringDigit);
    }
}