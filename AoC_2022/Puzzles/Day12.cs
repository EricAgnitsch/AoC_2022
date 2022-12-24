using AoC_2022._Lib;
using AoC_2022._Lib.Parsers;
using Lib.Algorithms;
using Lib.Graphs.Weighted;

namespace AoC_2022.Puzzles;

public class Day12 : AocProblem
{
    public override int PartOne(string[] lines)
    {
        var start = 0;
        foreach (var line in lines)
        {
            var idx = line.IndexOf("S", StringComparison.Ordinal);
            if (idx > -1)
            {
                start += idx;
                break;
            }

            start += line.Length;
        }
        
        var end = 0;
        foreach (var line in lines)
        {
            var idx = line.IndexOf("E", StringComparison.Ordinal);
            if (idx > -1)
            {
                end += idx;
                break;
            }

            end += line.Length;
        }
        
        var graph = ResetGraph(lines);

        var paths = new Dijkstra().Run(graph, start).ToList();

        PrintPathsTo(lines[0].Length, paths, start, end);
        
        return CountPathTo(paths, start, end);
    }

    private void PrintPathsTo(int rowLength, List<int> paths, int source, int destination)
    {
        var index = destination;

        var newPaths = Enumerable.Repeat("-", paths.Count).ToList();
        
        while (index != source)
        {
            var newIndex = paths[index];

            if (index < newIndex)
            {
                if (index / rowLength == newIndex / rowLength)
                {
                    newPaths[index] = ">";
                }
                else
                {
                    newPaths[index] = "v";
                }
            }
            else if (index > newIndex)
            {
                if (index / rowLength == newIndex / rowLength)
                {
                    newPaths[index] = "<";
                }
                else
                {
                    newPaths[index] = "^";
                }
            }
            index = paths[index];
            // Console.WriteLine(index);
        }

        newPaths[destination] = "E";
        newPaths[index] = "S";

        var result = "";
        for (var i = 0; i < newPaths.Count; i++)
        {
            if (i % rowLength == 0)
            {
                result += "\n";
            }
        
            result += $"{newPaths[i] + " ",-3}";
        }

        Console.WriteLine(result);
    }

    private int CountPathTo(IReadOnlyList<int> paths, int start, int destination)
    {
        var count = 0;

        var index = destination;
        
        while (index != start)
        {
            index = paths[index];
            if (index == 12)
            {
                Console.WriteLine();
            }
            count++;
        }

        return count;
    }

    public override int PartTwo(string[] lines)
    {

        var listOfStarts = new List<int>();

        var currentRow = 0;
        foreach (var line in lines.Select(l => l.Replace("S", "a")))
        {
            for (var i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (c == 'a')
                {
                    listOfStarts.Add(i + currentRow * lines[0].Length);
                }
            }

            currentRow++;
        }
        
        var end = 0;
        foreach (var line in lines)
        {
            var idx = line.IndexOf("E", StringComparison.Ordinal);
            if (idx > -1)
            {
                end += idx;
                break;
            }

            end += line.Length;
        }
        
        var shortestSteps = int.MaxValue;

        foreach (var pathStart in listOfStarts)
        {
            var graph = ResetGraph(lines);
            var paths = new Dijkstra().Run(graph, pathStart).ToList();
            
            PrintPathsTo(lines[0].Length, paths, pathStart, end);

            var pathLength = CountPathTo(paths, pathStart, end);

            if (pathLength < shortestSteps)
            {
                shortestSteps = pathLength;
            }
        }
        
        return shortestSteps;
    }

    private static WeightedGraph<DijkstraVertex> ResetGraph(string[] lines)
    {
        var grid = new GridParser().Parse(lines.Select(l => l.Replace("S", "a").Replace("E", "z")));
        var graph = new WeightedGraph<DijkstraVertex>();

        var index = 0;
        foreach (var row in grid.GridData)
        {
            foreach (var c in row)
            {
                var vertex = new DijkstraVertex(index);

                foreach (var gridElement in grid.GetNeighborsOf(index))
                {
                    if (gridElement.Value.CompareTo(c.Value) == 1 || gridElement.Value.CompareTo(c.Value) == 0)
                    {
                        vertex.AddEdge(gridElement.CIndex, 1);
                    }
                    else if (gridElement.Value.CompareTo(c.Value) < 0)
                    {
                        vertex.AddEdge(gridElement.CIndex, Math.Abs(gridElement.Value.CompareTo(c.Value)));
                    }
                    else
                    {
                        vertex.AddEdge(gridElement.CIndex, 100000);
                    }
                }

                graph.AddVertex(vertex);
                index++;
            }
        }

        return graph;
    }
}