using AoC_2022._Lib;

namespace AoC_2022.Puzzles;

public class Day01 : AocProblem
{
    public override int PartOne(string[] lines)
    {
        var elves = GetElvesCalories(lines);

        return elves.Max();
    }

    public override int PartTwo(string[] lines)
    {
        var elves = GetElvesCalories(lines);
        
        return elves.OrderByDescending(i => i).ToList().Take(3).Sum(i => i);
    }

    private static IEnumerable<int> GetElvesCalories(IEnumerable<string> lines)
    {
        var elves = new List<int> { 0 };

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                elves.Add(0);
            }
            else
            {
                elves[^1] += int.Parse(line);
            }
        }

        return elves;
    }
}