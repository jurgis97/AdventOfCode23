using AdventOfCode23.Day3;

const string dataFilesRoot = "../../../../AdventOfCode23.Day3/Data";

var day3 = new Day3();

var input = File.ReadAllLines($"{dataFilesRoot}/TaskInput.txt");
var result = day3.GetSum(input);

Console.WriteLine($"Day 3 Part 1: {result}");