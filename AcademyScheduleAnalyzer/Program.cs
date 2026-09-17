using System;
using System.Text;
using System.Globalization;
using BenchmarkDotNet.Running;
class Program
{
    static void Main(string[] args)
    {
        //******************************************************************
        // Part 1 - Starter Data
        //******************************************************************

        string[] sessionNames =
        {
            "C# Basics",
            "Arrays",
            "Functions",
            "Date and Time",
            "Exception Handling"
        };

        DateTime[] sessionDates =
        {
            new DateTime(2026, 9, 10, 18, 0, 0),
            new DateTime(2026, 9, 13, 18, 0, 0),
            new DateTime(2026, 9, 17, 18, 0, 0),
            new DateTime(2026, 9, 20, 18, 0, 0),
            new DateTime(2026, 9, 24, 18, 0, 0)
        };

        int[] sessionDurations =
        {
            180,
            240,
            180,
            240,
            180
        };


        //******************************************************************
        // Part 2 - Display All Sessions
        //******************************************************************

        DisplaySessions(
            sessionNames,
            sessionDates,
            sessionDurations
        );


        //******************************************************************
        // Part 3 - Search Session
        //******************************************************************

        Console.Write("Enter session name: ");

        string searchName = Console.ReadLine() ?? "";

        SearchSession(
            sessionNames,
            sessionDates,
            sessionDurations,
            searchName
        );


        //******************************************************************
        // Part 4.1 - Copy and Sort
        //******************************************************************

        string[] sortedNames = new string[sessionNames.Length];

        Array.Copy(
            sessionNames,
            sortedNames,
            sessionNames.Length
        );

        Array.Sort(sortedNames);

        Console.WriteLine("\nSorted Names:");

        foreach (string name in sortedNames)
        {
            Console.WriteLine(name);
        }


        //******************************************************************
        // Part 4.2 - Copy and Reverse
        //******************************************************************

        string[] reversedNames = new string[sessionNames.Length];

        Array.Copy(
            sessionNames,
            reversedNames,
            sessionNames.Length
        );

        Array.Reverse(reversedNames);

        Console.WriteLine("\nReversed Names:");

        foreach (string name in reversedNames)
        {
            Console.WriteLine(name);
        }


        //******************************************************************
        // Part 4.3 - Array.IndexOf
        //******************************************************************

        Console.Write("\nEnter session name to find index: ");

        string nameToFind = Console.ReadLine() ?? "";

        int index = Array.IndexOf(
            sessionNames,
            nameToFind
        );

        Console.WriteLine($"Index: {index}");


        //******************************************************************
        // Part 4.4 - Array.Exists
        //******************************************************************

        bool exists = Array.Exists(
            sessionNames,
            name => name == nameToFind
        );

        if (exists)
        {
            Console.WriteLine("Session exists.");
        }
        else
        {
            Console.WriteLine("Session does not exist.");
        }


        //******************************************************************
        // Part 4.5 - Array.Find
        //******************************************************************

        string? foundSession = Array.Find(
            sessionNames,
            name => name.StartsWith("A")
        );

        Console.WriteLine($"Found: {foundSession}");


        //******************************************************************
        // Part 4.6 - Array.FindIndex
        //******************************************************************

        int foundIndex = Array.FindIndex(
            sessionNames,
            name => name.StartsWith("A")
        );

        Console.WriteLine($"Found Index: {foundIndex}");


        //******************************************************************
        // Part 4.7 - Copy and Modify
        //******************************************************************

        string[] copiedNames = new string[sessionNames.Length];

        Array.Copy(
            sessionNames,
            copiedNames,
            sessionNames.Length
        );

        copiedNames[0] = "Changed Session";

        Console.WriteLine($"Copied: {copiedNames[0]}");
        Console.WriteLine($"Original: {sessionNames[0]}");


        //******************************************************************
        // Part 5 - Duration Statistics
        //******************************************************************

        Console.WriteLine(
            $"Total Duration: {GetTotalDuration(sessionDurations)}"
        );

        Console.WriteLine(
            $"Average Duration: {GetAverageDuration(sessionDurations)}"
        );

        Console.WriteLine(
            $"Shortest Duration: {GetShortestDuration(sessionDurations)}"
        );

        Console.WriteLine(
            $"Longest Duration: {GetLongestDuration(sessionDurations)}"
        );


        //******************************************************************
        // Part 6 - Display Session Details
        //******************************************************************

        DisplaySessionDetails(
            sessionNames[0],
            sessionDates[0],
            sessionDurations[0]
        );


        //******************************************************************
        // Part 7 - ref / out / Reference Type
        //******************************************************************

        int testDuration = 100;

        Console.WriteLine($"\nBefore ref: {testDuration}");

        AddTenMinutes(ref testDuration);

        Console.WriteLine($"After ref: {testDuration}");


        string outputName;

        bool sessionFound = GetSessionByIndex(
            sessionNames,
            sessionDates,
            sessionDurations,
            1,
            out outputName
        );

        Console.WriteLine($"Found: {sessionFound}");
        Console.WriteLine($"Session Name: {outputName}");

        Console.WriteLine($"Before array modification: {sessionDurations[0]}");

        ModifyDuration(sessionDurations);

        Console.WriteLine($"After array modification: {sessionDurations[0]}");


        //******************************************************************
        // Part 8 - params
        //******************************************************************

        Console.WriteLine(
            $"\nParams Total 1: {GetTotalUsingParams(100, 200, 300)}"
        );

        Console.WriteLine(
            $"Params Total 2: {GetTotalUsingParams(180, 240)}"
        );

        Console.WriteLine(
            $"Params Total 3: {GetTotalUsingParams(60, 120, 180, 240)}"
        );


        //******************************************************************
        // Part 9 - DateTime Details
        //******************************************************************

        DateTime selectedDate = sessionDates[0];

        Console.WriteLine("\nDateTime Details:");
        Console.WriteLine($"Year: {selectedDate.Year}");
        Console.WriteLine($"Month: {selectedDate.Month}");
        Console.WriteLine($"Day: {selectedDate.Day}");
        Console.WriteLine($"Hour: {selectedDate.Hour}");
        Console.WriteLine($"Minute: {selectedDate.Minute}");

        DateTime endTime = GetSessionEndTime(
            selectedDate,
            sessionDurations[0]
        );

        Console.WriteLine(
            $"Session End Time: {endTime:dd/MM/yyyy HH:mm}"
        );


        //******************************************************************
        // Part 10 - TimeSpan
        //******************************************************************

        TimeSpan difference = sessionDates[4] - sessionDates[0];

        Console.WriteLine(
            $"\nDifference Between First and Last Session: {difference.Days} days"
        );


        //******************************************************************
        // Part 11 - Past / Upcoming
        //******************************************************************

        Console.WriteLine("\nSession Status:");

        for (int i = 0; i < sessionDates.Length; i++)
        {
            if (sessionDates[i] < DateTime.Now)
            {
                Console.WriteLine($"{sessionNames[i]} - Past");
            }
            else
            {
                Console.WriteLine($"{sessionNames[i]} - Upcoming");
            }
        }


        //******************************************************************
        // Part 12 - Next Upcoming Session
        //******************************************************************

        int nextIndex = GetNextUpcomingSession(
            sessionNames,
            sessionDates
        );

        if (nextIndex != -1)
        {
            Console.WriteLine("\nNext Upcoming Session:");

            DisplaySessionDetails(
                sessionNames[nextIndex],
                sessionDates[nextIndex],
                sessionDurations[nextIndex]
            );
        }
        else
        {
            Console.WriteLine("No upcoming session.");
        }


        //******************************************************************
        // Part 13 - Date Formatting
        //******************************************************************

        Console.WriteLine(
            $"\nFormatted Date: {sessionDates[0]:yyyy-MM-dd HH:mm}"
        );


        //******************************************************************
        // Part 14 - Read Session Date
        //******************************************************************

        DateTime customDate = ReadSessionDate();

        Console.WriteLine(
            $"Custom Date: {customDate:yyyy-MM-dd HH:mm}"
        );


        //******************************************************************
        // Part 15 - Menu Input
        //******************************************************************

        int menuChoice = ReadMenuChoice();

        Console.WriteLine($"Selected Option: {menuChoice}");


        //******************************************************************
        // Part 16 - Invalid Index
        //******************************************************************

        try
        {
            Console.Write("\nEnter session index: ");

            int selectedIndex = int.Parse(
                Console.ReadLine() ?? ""
            );

            if (selectedIndex < 0 || selectedIndex >= sessionNames.Length)
            {
                throw new IndexOutOfRangeException(
                    "Session index is outside the valid range."
                );
            }

            Console.WriteLine(
                $"Selected Session: {sessionNames[selectedIndex]}"
            );
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


        //******************************************************************
        // Part 17 - Validate Duration
        //******************************************************************

        try
        {
            Console.Write("\nEnter duration: ");

            int duration = int.Parse(
                Console.ReadLine() ?? ""
            );

            ValidateDuration(duration);

            Console.WriteLine("Duration is valid.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


        //******************************************************************
        // Part 18 - finally
        //******************************************************************

        try
        {
            Console.Write("\nEnter a number: ");

            int number = int.Parse(
                Console.ReadLine() ?? ""
            );

            Console.WriteLine($"You entered: {number}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number format.");
        }
        finally
        {
            Console.WriteLine("Input operation finished.");
        }


        //******************************************************************
        // Part 19 - Build Report Using String
        //******************************************************************

        string report = BuildReportUsingString(
            sessionNames,
            sessionDates,
            sessionDurations
        );

        Console.WriteLine("\nReport Using String:");
        Console.WriteLine(report);


        //******************************************************************
        // Part 20 - Build Report Using StringBuilder
        //******************************************************************

        string reportUsingStringBuilder =
            BuildReportUsingStringBuilder(
                sessionNames,
                sessionDates,
                sessionDurations
            );

        Console.WriteLine("Report Using StringBuilder:");
        Console.WriteLine(reportUsingStringBuilder);
        BenchmarkRunner.Run<StringBenchmark>();

    }


    //******************************************************************
    // Part 2 - DisplaySessions
    //******************************************************************

    static void DisplaySessions(
        string[] names,
        DateTime[] dates,
        int[] durations)
    {
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"Name: {names[i]}");
            Console.WriteLine($"Date: {dates[i]:dd/MM/yyyy}");
            Console.WriteLine($"Start Time: {dates[i]:hh:mm tt}");
            Console.WriteLine($"Duration: {durations[i]} minutes");
        }
    }


    //******************************************************************
    // Part 3 - SearchSession
    //******************************************************************

    static void SearchSession(
        string[] names,
        DateTime[] dates,
        int[] durations,
        string searchName)
    {
        int index = Array.IndexOf(names, searchName);

        if (index == -1)
        {
            Console.WriteLine("Session not found.");
        }
        else
        {
            DisplaySessionDetails(
                names[index],
                dates[index],
                durations[index]
            );
        }
    }


    //******************************************************************
    // Part 5.1 - GetTotalDuration
    //******************************************************************

    static int GetTotalDuration(int[] durations)
    {
        int total = 0;

        for (int i = 0; i < durations.Length; i++)
        {
            total += durations[i];
        }

        return total;
    }


    //******************************************************************
    // Part 5.2 - GetAverageDuration
    //******************************************************************

    static double GetAverageDuration(int[] durations)
    {
        double Average =
            (double)GetTotalDuration(durations)
            / durations.Length;

        return Average;
    }


    //******************************************************************
    // Part 5.3 - GetShortestDuration
    //******************************************************************

    static int GetShortestDuration(int[] durations)
    {
        int shortest = durations[0];

        for (int i = 1; i < durations.Length; i++)
        {
            if (durations[i] < shortest)
            {
                shortest = durations[i];
            }
        }

        return shortest;
    }


    //******************************************************************
    // Part 5.4 - GetLongestDuration
    //******************************************************************

    static int GetLongestDuration(int[] durations)
    {
        int longest = durations[0];

        for (int i = 1; i < durations.Length; i++)
        {
            if (longest < durations[i])
            {
                longest = durations[i];
            }
        }

        return longest;
    }


    //******************************************************************
    // Part 6 - DisplaySessionDetails
    //******************************************************************

    static void DisplaySessionDetails(
        string name,
        DateTime date,
        int duration)
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Date: {date:dd/MM/yyyy}");
        Console.WriteLine($"Start Time: {date:hh:mm tt}");
        Console.WriteLine($"Duration: {duration} minutes");
    }


    //******************************************************************
    // Part 7.1 - ref
    //******************************************************************

    static void AddTenMinutes(ref int duration)
    {
        duration += 10;
    }


    //******************************************************************
    // Part 7.2 - out
    //******************************************************************

    static bool GetSessionByIndex(
        string[] names,
        DateTime[] dates,
        int[] durations,
        int index,
        out string sessionName)
    {
        if (index >= 0 && index < names.Length)
        {
            sessionName = names[index];

            Console.WriteLine(
                $"Session Duration: {durations[index]} minutes"
            );

            return true;
        }

        sessionName = "";

        return false;
    }


    //******************************************************************
    // Part 7.3 - Reference Type
    //******************************************************************

    static void ModifyDuration(int[] durations)
    {
        durations[0] = 999;
    }


    //******************************************************************
    // Part 8 - params
    //******************************************************************

    static int GetTotalUsingParams(params int[] durations)
    {
        int total = 0;

        for (int i = 0; i < durations.Length; i++)
        {
            total += durations[i];
        }

        return total;
    }


    //******************************************************************
    // Part 9 - GetSessionEndTime
    //******************************************************************

    static DateTime GetSessionEndTime(
        DateTime startTime,
        int duration)
    {
        DateTime endSession =
            startTime.AddMinutes(duration);

        return endSession;
    }


    //******************************************************************
    // Part 12 - GetNextUpcomingSession
    //******************************************************************

    static int GetNextUpcomingSession(
        string[] names,
        DateTime[] dates)
    {
        int nextIndex = -1;

        DateTime nextDate = DateTime.MaxValue;

        for (int i = 0; i < dates.Length; i++)
        {
            if (dates[i] > DateTime.Now &&
                dates[i] < nextDate)
            {
                nextDate = dates[i];
                nextIndex = i;
            }
        }

        return nextIndex;
    }


    //******************************************************************
    // Part 14 - ReadSessionDate
    //******************************************************************

    static DateTime ReadSessionDate()
    {
        DateTime date;
        bool readsession;

        do
        {
            Console.Write(
                "Enter date (yyyy-MM-dd HH:mm): "
            );

            string input =
                Console.ReadLine() ?? "";

            readsession = DateTime.TryParseExact(
                input,
                "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture,
                    DateTimeStyles.None,

                out date
            );

            if (!readsession)
            {
                Console.WriteLine(
                    "Invalid date format. Please try again."
                );
            }

        } while (!readsession);

        return date;
    }


    //******************************************************************
    // Part 15 - ReadMenuChoice
    //******************************************************************

    static int ReadMenuChoice()
    {
        int choice;

        while (true)
        {
            try
            {
                Console.Write("Enter menu choice: ");

                choice = int.Parse(
                    Console.ReadLine() ?? ""
                );

                return choice;
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Invalid input. Please enter a number."
                );
            }
        }
    }


    //******************************************************************
    // Part 17 - ValidateDuration
    //******************************************************************

    static void ValidateDuration(int duration)
    {
        if (duration <= 0)
        {
            throw new ArgumentException(
                "Duration must be greater than zero."
            );
        }
    }


    //******************************************************************
    // Part 19 - BuildReportUsingString
    //******************************************************************

    static string BuildReportUsingString(
        string[] names,
        DateTime[] dates,
        int[] durations)
    {
        string report = "";

        for (int i = 0; i < names.Length; i++)
        {
            report += $"Name : {names[i]}\n";
            report += $"Date : {dates[i]:dd/MM/yyyy}\n";
            report += $"Duration : {durations[i]} Minutes\n";
        }

        return report;
    }


    //******************************************************************
    // Part 20 - BuildReportUsingStringBuilder
    //******************************************************************

    static string BuildReportUsingStringBuilder(
        string[] names,
        DateTime[] dates,
        int[] durations)
    {
        StringBuilder report =
            new StringBuilder();

        for (int i = 0; i < names.Length; i++)
        {
            report.Append(
                $"Name : {names[i]}\n"
            );

            report.Append(
                $"Date : {dates[i]:dd/MM/yyyy HH:mm}\n"
            );

            report.Append(
                $"Duration : {durations[i]} Minutes\n"
            );
        }

        return report.ToString();
    }
}