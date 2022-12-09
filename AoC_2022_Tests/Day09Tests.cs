using AoC_2022_Tests._Lib;
using AoC_2022.Puzzles;
using FluentAssertions;

namespace AoC_2022_Tests;

public class Day09Tests : AocTestRunner
{
    public Day09Tests() : base("09")
    {
    }

    [Test]
    public void PartOneTest()
    {
        var solver = new Day09();
        
        solver.PartOne(Lines).Should().Be(13);
    }

    [Test]
    public void PartTwoTest()
    {
        var solver = new Day09();
        
        solver.PartTwo(Lines).Should().Be(1);
    }
}