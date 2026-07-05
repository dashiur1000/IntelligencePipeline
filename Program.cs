using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;
using IntelligencePipeline.Storage;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
namespace IntelligencePipeline;
class Program
{
    public static void Main(string[] args)
    {
        var Pipeline = new ReportPipeline();
        Console.WriteLine("Welcome to the report programmer!");
        while(true)
        {
            Console.Write("============\nTo insert a report enter 1" +
                "\nTo displaying proper reports enter 2" +
                "\nSearch for a specific word in reports enter 3" +
                "\nSort by Status, Classification, Priority, SourceType, Date Range enter 4"+
                "\n============" +
                "\nenter: ");
            string generalChoice = Console.ReadLine();
            if (generalChoice == "1")
            {
                int reportLoop = 1;
                while (reportLoop == 1)
                {
                    Console.Write("Select the report source\nDrone (1) Soldier (2) Radar (3) Signal (4) or (0) to return to main menu: ");
                    string reportType = Console.ReadLine();
                    if (reportType == "1")
                    {
                        DateTime Timestamp = InputAndCheck<DateTime>("Enter time (yyyy-mm-dd hh:mm:ss): ", DateTime.TryParse);
                        double Latitude = InputAndCheck<double>("Enter latitude between: 29.5000 – 33.5000: ", double.TryParse);
                        double Longitude = InputAndCheck<double>("Enter Longitude between: 34.0000 – 36.0000: ", double.TryParse);
                        Console.Write("Enter Description: ");
                        string description = Console.ReadLine();
                        int altitude = InputAndCheck<int>("Enter Altitude between: 100 - 10000: ", int.TryParse);
                        int imageQuality = InputAndCheck<int>("Enter ImageQuality between: 1 - 100: ", int.TryParse);
                        Report newReport = new DroneReport(0, Timestamp, Latitude, Longitude, description, altitude, imageQuality);
                        Pipeline.ProcessReport(newReport);
                    }
                    if (reportType == "2")
                    {
                        DateTime Timestamp = InputAndCheck<DateTime>("Enter time (yyyy-mm-dd hh:mm:ss): ", DateTime.TryParse);
                        double Latitude = InputAndCheck<double>("Enter latitude between: 29.5000 – 33.5000: ", double.TryParse);
                        double Longitude = InputAndCheck<double>("Enter Longitude between: 34.0000 – 36.0000: ", double.TryParse);
                        Console.Write("Enter Description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter soldier name: ");
                        string SoldierName = Console.ReadLine();
                        Console.Write("Enter soldier id: ");
                        string SoldierId = Console.ReadLine();
                        Console.Write("Enter unit: ");
                        string SoldierUnit = Console.ReadLine();
                        int ConfidenceLevel = InputAndCheck<int>("Enter Confidence Level between: 1 - 5: ", int.TryParse);
                        Report newReport = new SoldierReport(0, Timestamp, Latitude, Longitude, description, SoldierName, SoldierId, SoldierUnit, ConfidenceLevel);
                        Pipeline.ProcessReport(newReport);
                    }
                    if (reportType == "3")
                    {
                        DateTime Timestamp = InputAndCheck<DateTime>("Enter time (yyyy-mm-dd hh:mm:ss): ", DateTime.TryParse);
                        double Latitude = InputAndCheck<double>("Enter latitude between: 29.5000 – 33.5000: ", double.TryParse);
                        double Longitude = InputAndCheck<double>("Enter Longitude between: 34.0000 – 36.0000: ", double.TryParse);
                        Console.Write("Enter Description: ");
                        string description = Console.ReadLine();
                        int Speed = InputAndCheck<int>("Enter speed between: 0 - 2000: ", int.TryParse);
                        int Direction = InputAndCheck<int>("Enter direction between: 0 - 360: ", int.TryParse);
                        int Distance = InputAndCheck<int>("Enter distance between: 100 - 100000: ", int.TryParse);
                        Report newReport = new RadarReport(0, Timestamp, Latitude, Longitude, description, Speed, Direction, Distance);
                        Pipeline.ProcessReport(newReport);
                    }
                    if (reportType == "4")
                    {
                        DateTime Timestamp = InputAndCheck<DateTime>("Enter time (yyyy-mm-dd hh:mm:ss): ", DateTime.TryParse);
                        double Latitude = InputAndCheck<double>("Enter latitude between: 29.5000 – 33.5000: ", double.TryParse);
                        double Longitude = InputAndCheck<double>("Enter Longitude between: 34.0000 – 36.0000: ", double.TryParse);
                        Console.Write("Enter Description: ");
                        string description = Console.ReadLine();
                        double Frequency = InputAndCheck<double>("Enter Frequency between: 1.0 - 3000.0: ", double.TryParse);
                        Console.Write("Enter Content: ");
                        string Content = Console.ReadLine();
                        Language Language = InputAndCheck<Language>("Enter Language (Hebrew, Arabic, English, Russian, Other): ", Enum.TryParse<Language>);
                        int SignalStrength = InputAndCheck<int>("Enter Signal Strength between -120 - 0: ", int.TryParse);
                        Report newReport = new SignalReport(0, Timestamp, Latitude, Longitude, description, Frequency, Content, Language, SignalStrength);
                        Pipeline.ProcessReport(newReport);
                    }
                    if (reportType == "0")
                    {
                        break;
                    }
                }
            }
            if(generalChoice == "2")
            {
                if (Pipeline.GetValidatedCount() == 0)
                {
                    Console.WriteLine("No reports in Validated status");
                    continue;
                }
                Pipeline.GetValidatedReports();
            }
            if (generalChoice == "3")
            {
                Console.Write("What do you want to search for: ");
                string word = Console.ReadLine();
                var result = Pipeline.Search(word);
                if (result.Count == 0)
                {
                    Console.WriteLine("Not found");
                }
                foreach (var report in result)
                {
                    Console.WriteLine(report.ToString());
                }
            }
            if(generalChoice == "4")
            {
                Console.Write("Sort by Status (1), Classification(2), Priority(3), SourceType(4), Date Range(5): ");
                string NumSortBy = Console.ReadLine();
                if(NumSortBy == "1")
                {
                    SortBy<ReportStatus>(
                        status => Pipeline.GetByStatus(status),
                        "What status do you want to search for (New, Validating, Validated, Rejected, InProgress, Completed): ",
                        Enum.TryParse<ReportStatus>
                    );
                }
                if(NumSortBy == "2")
                {
                    SortBy<Classification>(
                        classification => Pipeline.GetByClassification(classification),
                        "What classification do you want to search for (Unclassified, Restricted, Secret, TopSecret): ",
                        Enum.TryParse<Classification>
                    );
                }
                if(NumSortBy == "3")
                {
                    SortBy<Priority>(
                        priority => Pipeline.GetByPriority(priority),
                        "What priority do you want to search for (Low, Medium, High, Critical): ",
                        Enum.TryParse<Priority>
                    );
                }
                if(NumSortBy == "4")
                {
                    Console.Write("Enter Source Type: ");
                    string type = Console.ReadLine();
                    var results = Pipeline.GetBySourceType(type);
                    if(results.Count == 0)
                    {
                        Console.WriteLine("No reports found.");
                        continue;
                    }
                    foreach(var result in results)
                    {
                        Console.WriteLine(result.ToString());
                    }
                }
                if(NumSortBy == "5")
                {
                    Console.Write("Enter first date: ");
                    string firsDateStr = Console.ReadLine();
                    Console.Write("Enter second date: ");
                    string secondDateStr = Console.ReadLine();
                    if(!DateTime.TryParse(firsDateStr, out DateTime firsDate))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        continue;
                    }
                    if (!DateTime.TryParse(secondDateStr, out DateTime secondDate))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        continue;
                    }
                    var results = Pipeline.GetByDate(firsDate, secondDate);
                    if (results.Count == 0)
                    {
                        Console.WriteLine("No reports found.");
                        continue;
                    }
                    foreach (var result in results)
                    {
                        Console.WriteLine(result.ToString());
                    }

                }


            }
            if(generalChoice == "0")
            {
                break;
            }
        }
        
    }
                   
            
        
        
    
    private static void DisplayReport(Report report)
    {
        
    }
    
    public delegate bool TryParseDelegate<T>(string input, out T result);
    public static T InputAndCheck<T>(string prompt, TryParseDelegate<T> parser)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if(parser(input, out T result)) return result;
            Console.WriteLine("Invalid input. Please try again.");
        }
    }
    public static void SortBy<T>(Func<T, List<Report>> processFunc, string prompt, TryParseDelegate<T> parser)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!parser(input, out T resultWord))
            {
                if (input == "0") break;
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }
            else
            {
                var result = processFunc(resultWord);
                if (result.Count == 0)
                {
                    Console.WriteLine($"No report found.");
                }
                else
                {
                    foreach (var report in result)
                    {
                        Console.WriteLine(report.ToString());
                    }
                    break;
                }
                
            }
        }
    }
}