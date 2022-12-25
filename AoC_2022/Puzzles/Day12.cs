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
        var paths = new Dijkstra().Run(graph, end).ToList();

        PrintPathsTo(lines[0].Length, paths, end, start);
        
        return CountPathTo(paths, end, start);
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

        var graph = ResetGraph(lines);
        var paths = new Dijkstra().Run(graph, end).ToList();

        return listOfStarts.Select(pathStart => CountPathTo(paths, end, pathStart)).Prepend(int.MaxValue).Min();
    }

    private void PrintPathsTo(int rowLength, List<int> paths, int source, int destination)
    {
        var index = destination;

        var newPaths = Enumerable.Repeat("-", paths.Count).ToList();
        
        while (index != -1 && index != source)
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
        }

        newPaths[destination] = "E";
        newPaths[source] = "S";

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
        
        while (index != -1 && index != start)
        {
            index = paths[index];
            count++;
        }

        return index != -1 ? count : int.MaxValue;
    }

    private WeightedGraph<DijkstraVertex> ResetGraph(string[] lines)
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
                    if (c.Value.CompareTo(gridElement.Value) == 1 || c.Value.CompareTo(gridElement.Value) == 0)
                    {
                        vertex.AddEdge(gridElement.CIndex, 1);
                    }
                    else if (c.Value.CompareTo(gridElement.Value) < 0)
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