using System.Numerics;

namespace AoC_2022._Lib.Extensions;

public static class ListExtensions
{
    public static int PopFirst(this List<int> items)
    {
        var result = items[0];
        items.RemoveAt(0);
        return result;
    }
}