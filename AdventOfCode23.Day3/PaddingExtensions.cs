namespace AdventOfCode23.Day3;

public static class PaddingExtensions
{
    public static IList<string> AddPadding(this string[] lines)
    {
        var firstLineLength = lines.First().Length;
        var firstLinePadding = "".PadLeft(firstLineLength, '.');

        var lastLineLength = lines.Last().Length;
        var lastLinePadding = "".PadLeft(lastLineLength, '.');

        var paddedLines = new List<string> {firstLinePadding};
        paddedLines.AddRange(lines);
        paddedLines.Add(lastLinePadding);
        return paddedLines;
    }
}