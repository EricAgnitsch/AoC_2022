namespace AoC_2022._Lib.Parsers;

public class Grid
{
    public List<List<GridElement>> GridData { get; set; } = new();

    public List<GridElement> GetNeighborsOf(int element)
    {
        var gridRowLength = GridData.First().Count;
    
        var elementRow = element / gridRowLength;
        var elementCol = element % gridRowLength;

        return GridData[elementRow][elementCol].Neighbors;
    }

    public void AddElement(char c, int cIndex)
    {
        GridData.Last().Add(new GridElement(c, cIndex));

        var lastElement = GridData.Last().Last();

        if (GridData.Last().Count > 1)
        {
            var previousElement = GridData.Last().Skip(GridData.Last().Count - 2).First();
            
            lastElement.Neighbors.Add(previousElement);
            previousElement.Neighbors.Add(lastElement);
        }

        if (GridData.Count > 1)
        {
            var index = GridData.Last().Count - 1;
            var previousElement = GridData.Skip(GridData.Count - 2).First()[index];
            
            lastElement.Neighbors.Add(previousElement);
            previousElement.Neighbors.Add(lastElement);
        }
    }

    public void NewRow()
    {
        GridData.Add(new List<GridElement>());
    }
}