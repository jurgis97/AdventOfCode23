namespace AdventOfCode23.Day3;

public static class SymbolExtensions
{
    public static bool IsSymbol(this char symbol)
    {
        return symbol != '.' && !int.TryParse(symbol.ToString(), out _);
    }
}