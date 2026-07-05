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
            Console.Write("To insert a report enter 1:\nTo displaying proper reports enter 2:");
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
                    Console.WriteLine("No reports in status");
                    continue;
                }
                Pipeline.GetValidatedReports();
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
}