namespace AdventOfCode23.Day3;

using System.Text.RegularExpressions;

public class Day3
{
    public int GetSum(string[] lines)
    {
        var firstLineLength = lines.First().Length;
        var firstLinePadding = "".PadLeft(firstLineLength, '.');

        var lastLineLength = lines.Last().Length;
        var lastLinePadding = "".PadLeft(lastLineLength, '.');

        var paddedLines = new List<string> {firstLinePadding};
        paddedLines.AddRange(lines);
        paddedLines.Add(lastLinePadding);

        var sum = 0;

        for (var i = 1; i < paddedLines.Count - 1; i++)
        {
            var upperLine = paddedLines[i - 1];
            var middleLine = paddedLines[i];
            var lowerLine = paddedLines[i + 1];

            var regex = new Regex("([0-9])*");
            var matches = regex.Matches(middleLine).Where(x => x.Value != "");

            foreach (Match match in matches)
            {
                var digit = int.Parse(match.Value);

                var leftIndex = Math.Max(match.Index - 1, 0);
                var rightIndexUpper = Math.Min(match.Index + match.Length, upperLine.Length - 1);
                var rightIndexMiddle = Math.Min(match.Index + match.Length, middleLine.Length - 1);
                var rightIndexLower = Math.Min(match.Index + match.Length, lowerLine.Length - 1);

                var hasHorizontalAdjacentSymbols = IsSymbol(middleLine[leftIndex])
                                                   || IsSymbol(middleLine[rightIndexMiddle]);
                var hasTopAdjacentSymbols = upperLine
                    .Substring(leftIndex, rightIndexUpper - leftIndex + 1)
                    .Any(IsSymbol);

                var hasBottomAdjacentSymbols = lowerLine
                    .Substring(leftIndex, rightIndexLower - leftIndex + 1)
                    .Any(IsSymbol);

                if (hasHorizontalAdjacentSymbols || hasTopAdjacentSymbols || hasBottomAdjacentSymbols)
                {
                    sum += digit;
                }
            }
        }

        return sum;
    }
    
    private bool IsSymbol(char symbol)
    {
        return symbol != '.' && !int.TryParse(symbol.ToString(), out _);
    }
}