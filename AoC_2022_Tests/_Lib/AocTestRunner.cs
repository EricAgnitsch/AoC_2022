using AoC_2022._Lib;

namespace AoC_2022_Tests._Lib;

public abstract class AocTestRunner<T> where T : AocProblem
{
    protected readonly string[] Lines;
    protected readonly AocProblem Solver;

    protected AocTestRunner()
    {
        // I hate myself for doing this but lmao
        var day = typeof(T).Name[3..];
        var classType = typeof(T).Assembly.GetTypes().First(t => t.Name == "Day" + day);
        Solver = Activator.CreateInstance(classType) as AocProblem ?? throw new InvalidOperationException();
        Lines = File.ReadAllLines(GetFileName(day));
    }

    private string GetFileName(string day)
    {
        return Environment.CurrentDirectory + $"/Data/{day}/example.txt";
    }
}