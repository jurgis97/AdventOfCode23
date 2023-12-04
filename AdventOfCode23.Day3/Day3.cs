namespace AdventOfCode23.Day3;

using System.Text.RegularExpressions;

public class Day3
{
    public int GetSum(string[] lines)
    {
        var paddedLines = lines.AddPadding();

        var sum = 0;
        for (var i = 1; i < paddedLines.Count - 1; i++)
        {
            var upperLine = paddedLines[i - 1];
            var middleLine = paddedLines[i];
            var lowerLine = paddedLines[i + 1];

            var regex = new Regex("([0-9])*");
            var matches = regex.Matches(middleLine).Where(x => x.Value != "");

            foreach (var match in matches)
            {
                var digit = int.Parse(match.Value);

                var leftIndex = Math.Max(match.Index - 1, 0);
                var rightIndexUpper = Math.Min(match.Index + match.Length, upperLine.Length - 1);
                var rightIndexMiddle = Math.Min(match.Index + match.Length, middleLine.Length - 1);
                var rightIndexLower = Math.Min(match.Index + match.Length, lowerLine.Length - 1);

                var horizontalAdjacentSymbols = 
                    $"{middleLine[leftIndex]}{middleLine[rightIndexMiddle]}".Any(x => x.IsSymbol());
                
                var topAdjacentSymbols = upperLine
                    .Substring(leftIndex, rightIndexUpper - leftIndex + 1)
                    .Any(x => x.IsSymbol());

                var bottomAdjacentSymbols = lowerLine
                    .Substring(leftIndex, rightIndexLower - leftIndex + 1)
                    .Any(x => x.IsSymbol());

                if (horizontalAdjacentSymbols || topAdjacentSymbols || bottomAdjacentSymbols)
                {
                    sum += digit;
                }
            }
        }

        return sum;
    }

    public int GetGearRatiosSum(string[] lines)
    {
        var paddedLines = lines.AddPadding();

        var sum = 0;
        for (var i = 1; i < paddedLines.Count - 1; i++)
        {
            var upperLine = paddedLines[i - 1];
            var middleLine = paddedLines[i];
            var lowerLine = paddedLines[i + 1];

            var regex = new Regex(@"\*");
            var matches = regex.Matches(middleLine).Where(x => x.Value != "");

            foreach (var match in matches)
            {
                var leftIndex = Math.Max(match.Index, 0);
                var rightIndexUpper = Math.Min(match.Index + 1, upperLine.Length);
                var rightIndexMiddle = Math.Min(match.Index + 1, middleLine.Length);
                var rightIndexLower = Math.Min(match.Index + 1, lowerLine.Length);

                var anyToRight = new Regex("^[0-9]*").Match(middleLine[rightIndexMiddle..]);
                var anyToLeft = new Regex("[0-9]*$").Match(middleLine[..leftIndex]);
                var anyToTop = new Regex("[0-9]*").Matches(upperLine)
                    .Where(x => !string.IsNullOrEmpty(x.Value)
                                      && (InRange(leftIndex, x.Index,rightIndexUpper)
                                      || InRange(leftIndex, x.Index + x.Length,rightIndexUpper)));
                var anyToBottom = new Regex("[0-9]*").Matches(lowerLine)
                    .Where(x => !string.IsNullOrEmpty(x.Value)
                                && (InRange(leftIndex, x.Index,rightIndexLower)
                                    || InRange(leftIndex, x.Index + x.Length,rightIndexLower)));
                
                var matchesAround = new List<Match>();
                matchesAround.Add(anyToRight);
                matchesAround.Add(anyToLeft);
                matchesAround.AddRange(anyToTop);
                matchesAround.AddRange(anyToBottom);
                
                var listOfInts = matchesAround
                    .Where(x => !string.IsNullOrEmpty(x.Value))
                    .Select(x => int.Parse(x.Value))
                    .ToList();
                if (listOfInts.Count > 1)
                {
                    var gearRatio = 1;
                    listOfInts.ForEach(x => gearRatio *= x);
                    sum += gearRatio;
                }
            }
        }

        return sum;
    }
    
    private bool InRange(int min, int value, int max) => min <= value && value <= max;
}