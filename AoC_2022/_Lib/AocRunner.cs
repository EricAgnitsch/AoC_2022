using System.Diagnostics;

namespace AoC_2022._Lib;

public class AocRunner
{
    private readonly AocProblem _problem;
    private readonly string _day;
    private readonly AocFileType _fileType;

    public AocRunner(AocProblem problem, string day, AocFileType fileType)
    {
        _problem = problem;
        _day = day;
        _fileType = fileType;
    }

    private string GetFileName(string day, AocFileType fileType)
    {
        return Environment.CurrentDirectory +
               $"/Data/{day}/{(fileType == AocFileType.EXAMPLE ? "example" : "real")}.txt";
    }

    public void Run(AocProblemType type)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        var lines = File.ReadAllLines(GetFileName(_day, _fileType));
        
        if (type == AocProblemType.PART_ONE)
        {
            Console.WriteLine($"Part 1 -- day {_day} with {_fileType} data: {_problem.PartOne(lines)}");
        }
        else if (type == AocProblemType.PART_TWO)
        {
            Console.WriteLine($"Part 2 -- day {_day} with {_fileType} data: {_problem.PartTwo(lines)}");
        }

        stopwatch.Stop();
        Console.WriteLine($"~~ Puzzle time: {stopwatch.Elapsed} ~~");
    }
}