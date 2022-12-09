using AoC_2022_Tests._Lib;
using AoC_2022.Puzzles;
using FluentAssertions;

namespace AoC_2022_Tests;

public class Day01Tests : AocTestRunner<Day01>
{
    [Test]
    public void PartOneTest()
    {
        Solver.PartOne(Lines).Should().Be(24000);
    }

    [Test]
    public void PartTwoTest()
    {
        Solver.PartTwo(Lines).Should().Be(45000);
    }
}