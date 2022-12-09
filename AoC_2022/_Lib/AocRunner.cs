using System.Diagnostics;

namespace AoC_2022._Lib;

public class AocRunner
{
    private readonly AocProblem _problem;
    private readonly string _day;
    private readonly AocFileType _fileType;

    public AocRunner(AocProblem problem, AocFileType fileType)
    {
        _problem = problem;
        _day = problem.GetType().Name[3..];
        _fileType = fileType;
    }

    private static string GetFileName(string day, AocFileType fileType)
    {
        return Environment.CurrentDirectory +
               $"/Data/{day}/{(fileType == AocFileType.Example ? "example" : "real")}.txt";
    }

    public AocRunner RunPartOne()
    {
        Console.WriteLine(new string('~', 50));
        
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var lines = File.ReadAllLines(GetFileName(_day, _fileType));

        Console.WriteLine($"Part 1 -- day {_day} with {_fileType} data: {_problem.PartOne(lines)}");

        stopwatch.Stop();
        Console.WriteLine($"~~ Puzzle time: {stopwatch.ElapsedMilliseconds}ms ~~");
        Console.WriteLine(new string('~', 50));
        
        return this;
    }

    public void RunPartTwo()
    {
        Console.WriteLine(new string('~', 50));
        
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var lines = File.ReadAllLines(GetFileName(_day, _fileType));

        Console.WriteLine($"Part 2 -- day {_day} with {_fileType} data: {_problem.PartTwo(lines)}");

        stopwatch.Stop();
        Console.WriteLine($"~~ Puzzle time: {stopwatch.ElapsedMilliseconds}ms ~~");
        Console.WriteLine(new string('~', 50));
    }
}