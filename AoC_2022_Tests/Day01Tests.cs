using AoC_2022_Tests._Lib;
using AoC_2022.Puzzles;
using FluentAssertions;

namespace AoC_2022_Tests;

public class Day01Tests : AocTestRunner
{
    public Day01Tests() : base("01")
    {
    }

    [Test]
    public void PartOneTest()
    {
        var solver = new Day01();
        
        solver.PartOne(Lines).Should().Be(24000);
    }

    [Test]
    public void PartTwoTest()
    {
        var solver = new Day01();
        
        solver.PartTwo(Lines).Should().Be(45000);
    }
}