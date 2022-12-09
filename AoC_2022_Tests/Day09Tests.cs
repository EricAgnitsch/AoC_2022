using AoC_2022_Tests._Lib;
using AoC_2022.Puzzles;
using FluentAssertions;

namespace AoC_2022_Tests;

public class Day09Tests : AocTestRunner<Day09>
{
    [Test]
    public void PartOneTest()
    {
        Solver.PartOne(Lines).Should().Be(13);
    }

    [Test]
    public void PartTwoTest()
    {
        Solver.PartTwo(Lines).Should().Be(1);
    }
}