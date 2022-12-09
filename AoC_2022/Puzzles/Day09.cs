using AoC_2022._Lib;

namespace AoC_2022.Puzzles;

public class Day09 : AocProblem
{
    public override int PartOne(string[] lines)
    {
        var grid = BuildAndMove(lines, 1);

        return grid.Visited.Count;
    }

    public override int PartTwo(string[] lines)
    {
        var grid = BuildAndMove(lines, 9);

        return grid.Visited.Count;
    }

    private PretendGrid BuildAndMove(string[] lines, int knots)
    {
        var grid = new PretendGrid(knots);

        foreach (var line in lines)
        {
            switch (line[..1])
            {
                case "R":
                    for (var i = 0; i < int.Parse(line[2..]); i++)
                    {
                        grid.MoveHead(0, 1);
                    }

                    break;
                case "D":
                    for (var i = 0; i < int.Parse(line[2..]); i++)
                    {
                        grid.MoveHead(-1, 0);
                    }

                    break;
                case "L":
                    for (var i = 0; i < int.Parse(line[2..]); i++)
                    {
                        grid.MoveHead(0, -1);
                    }

                    break;
                case "U":
                    for (var i = 0; i < int.Parse(line[2..]); i++)
                    {
                        grid.MoveHead(1, 0);
                    }

                    break;
            }
        }

        return grid;
    }

    public class PretendGrid
    {
        public Position Head { get; }
        public List<Position> Visited { get; } = new();

        public PretendGrid(int knots)
        {
            Head = new Position(0, 0);
            var currentKnot = Head;
            for (var i = 0; i < knots; i++)
            {
                var knot = new Position(0, 0);
                currentKnot.NextKnot = knot;
                currentKnot = knot;
            }
        }

        public void MoveHead(int x, int y)
        {
            Head.X += x;
            Head.Y += y;
            MoveKnots();
        }

        private void MoveKnots()
        {
            var currentKnot = Head;
            while (currentKnot.NextKnot != null)
            {
                if (!currentKnot.NextTo(currentKnot.NextKnot))
                {
                    currentKnot.NextKnot.MoveCloserTo(currentKnot);
                }

                currentKnot = currentKnot.NextKnot;
            }

            if (!Visited.Any(v => v.X == currentKnot.X && v.Y == currentKnot.Y))
            {
                Visited.Add(new Position(currentKnot.X, currentKnot.Y));
            }
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Position NextKnot { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool NextTo(Position target)
        {
            return Math.Abs(target.X - X) <= 1 && Math.Abs(target.Y - Y) <= 1;
        }

        public void MoveCloserTo(Position target)
        {
            if (X == target.X)
            {
                Y += (target.Y - Y) / 2;
            }
            else if (Y == target.Y)
            {
                X += (target.X - X) / 2;
            }
            else
            {
                X += target.X > X ? 1 : -1;
                Y += target.Y > Y ? 1 : -1;
            }
        }
    }
}