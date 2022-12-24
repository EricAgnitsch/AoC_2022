using AoC_2022_Tests._Lib;
using AoC_2022.Puzzles;
using FluentAssertions;

namespace AoC_2022_Tests;

public class Day12Tests : AocTestRunner<Day12>
{
    [Test]
    public void PartOneTest()
    {
        Solver.PartOne(Lines).Should().Be(31);
    }

    [Test]
    public void PartTwoTest()
    {
        Solver.PartTwo(Lines).Should().Be(29);
    }
}