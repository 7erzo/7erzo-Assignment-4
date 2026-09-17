using BenchmarkDotNet.Attributes;
using System.Text;

[MemoryDiagnoser]
public class StringBenchmark
{
    //******************************************************************
    // Benchmark Data
    //******************************************************************

    private string[] names =
    {
        "C# Basics",
        "Arrays",
        "Functions",
        "Date and Time",
        "Exception Handling"
    };

    private DateTime[] dates =
    {
        new DateTime(2026, 9, 10, 18, 0, 0),
        new DateTime(2026, 9, 13, 18, 0, 0),
        new DateTime(2026, 9, 17, 18, 0, 0),
        new DateTime(2026, 9, 20, 18, 0, 0),
        new DateTime(2026, 9, 24, 18, 0, 0)
    };

    private int[] durations =
    {
        180,
        240,
        180,
        240,
        180
    };


    //******************************************************************
    // Part 22 - Iterations
    //******************************************************************

    [Params(100, 1000, 10000, 100000)]
    public int Iterations { get; set; }


    //******************************************************************
    // String Concatenation
    //******************************************************************

    [Benchmark]
    public string StringConcatenation()
    {
        string report = "";

        for (int iteration = 0; iteration < Iterations; iteration++)
        {
            report = "";

            for (int i = 0; i < names.Length; i++)
            {
                report += $"Name: {names[i]}\n";
                report += $"Date: {dates[i]:dd/MM/yyyy HH:mm}\n";
                report += $"Duration: {durations[i]} Minutes\n";
            }
        }

        return report;
    }


    //******************************************************************
    // StringBuilder Concatenation
    //******************************************************************

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder report = new StringBuilder();

        for (int iteration = 0; iteration < Iterations; iteration++)
        {
            report.Clear();

            for (int i = 0; i < names.Length; i++)
            {
                report.Append($"Name: {names[i]}\n");
                report.Append($"Date: {dates[i]:dd/MM/yyyy HH:mm}\n");
                report.Append($"Duration: {durations[i]} Minutes\n");
            }
        }

        return report.ToString();
    }
}