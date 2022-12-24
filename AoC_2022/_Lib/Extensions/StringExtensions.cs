namespace AoC_2022._Lib.Extensions;

public static class StringExtensions
{
    public static string TextAfterFirstIndexOf(this string line, string textToSkip)
    {
        if (string.IsNullOrEmpty(line) || string.IsNullOrEmpty(textToSkip) || !line.Contains(textToSkip)) return "";
        var index = line.IndexOf(textToSkip, StringComparison.Ordinal) + textToSkip.Length;
        return index < line.Length ? line[index..] : "";
    }
}