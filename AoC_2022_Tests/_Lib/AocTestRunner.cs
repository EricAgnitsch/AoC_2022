namespace AoC_2022_Tests._Lib;

public abstract class AocTestRunner
{
    protected readonly string[] Lines;

    protected AocTestRunner(string day)
    {
        Lines = File.ReadAllLines(GetFileName(day));
    }

    private string GetFileName(string day)
    {
        return Environment.CurrentDirectory + $"/Data/{day}/example.txt";
    }
}