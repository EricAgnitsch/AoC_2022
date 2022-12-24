namespace AoC_2022._Lib.Parsers;

public class GridParser
{
    public Grid Parse(IEnumerable<string> lines)
    {
        var grid = new Grid();

        var index = 0;
        
        foreach (var line in lines)
        {
            grid.NewRow();
            
            foreach (var c in line)
            {
                grid.AddElement(c, index);
                index++;
            }
        }

        return grid;
    }
}