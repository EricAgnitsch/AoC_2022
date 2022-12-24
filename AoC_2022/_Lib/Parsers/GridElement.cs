namespace AoC_2022._Lib.Parsers;

public class GridElement
{
    public List<GridElement> Neighbors { get; set; } = new();
    public char Value { get; set; }
    public int CIndex;

    public GridElement(char value, int cIndex)
    {
        CIndex = cIndex;
        Value = value;
    }
}