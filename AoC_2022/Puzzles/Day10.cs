using AoC_2022._Lib;

namespace AoC_2022.Puzzles;

public class Day10 : AocProblem
{
    public override int PartOne(string[] lines)
    {
        var cpu = ParseInstructions(lines);

        return cpu.SignalStrengths.Sum();
    }

    public override int PartTwo(string[] lines)
    {
        ParseInstructions(lines);
        return 0;
    }

    private static CPU ParseInstructions(string[] lines)
    {
        var cpu = new CPU();

        foreach (var line in lines)
        {
            if (line == "noop")
            {
                cpu.Noop();
            }
            else if (line.StartsWith("addx"))
            {
                cpu.AddX(int.Parse(line[5..]));
            }
        }

        return cpu;
    }

    public class CPU
    {
        public int X { get; set; } = 1;
        public int Cycle { get; set; }
        public List<int> SignalStrengths { get; } = new();
        public string CRTRow { get; set; }

        public void UpdateCRT()
        {
            var pixel = ".";
            
            if (Math.Abs(Cycle % 40 - X) <= 1)
            {
                pixel = "#";
            }

            CRTRow += pixel;

            if (CRTRow.Length % 40 != 0) return;
            Console.WriteLine(CRTRow);
            CRTRow = "";
        }

        public void AddX(int v)
        {
            CycleStep(2);
            X += v;
        }

        public void Noop()
        {
            CycleStep(1);
        }

        private void CycleStep(int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                UpdateCRT();
                Cycle++;
                if (Cycle % 40 == 20)
                {
                    SignalStrengths.Add(Cycle * X);
                }
            }
        }
    }
}