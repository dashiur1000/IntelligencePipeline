using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the report programmer!");
        Console.WriteLine("If you want to insert a report, enter 1: ");
        string firsInput = Console.ReadLine();
        if(firsInput == "1")
        {
            int reportLoop = 1;
            while(reportLoop == 1)
            {
                Console.WriteLine("Select the drone report source Enter 1: ");
                string reportType = Console.ReadLine();
                if (reportType == "1")
                {
                    Console.WriteLine("Enter reportId: ");
                    string reportIdStr = Console.ReadLine();
                    if (!int.TryParse(reportIdStr, out int reportId))
                    {
                        Console.WriteLine("The character entered is invalid.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Enter time (yyyy-mm-dd hh:mm:ss): ");
                        string dateTimeStr = Console.ReadLine();
                        if (!DateTime.TryParse(dateTimeStr, out DateTime Timestamp))
                        {
                            Console.WriteLine("The character entered is invalid.");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Enter latitude");
                            string latitudeStr = Console.ReadLine();
                            if(!double.TryParse(latitudeStr, out double Latitude))
                            {
                                Console.WriteLine("The character entered is invalid.");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Enter Longitude: ");
                                string longitudeStr = Console.ReadLine();
                                if(!double.TryParse(longitudeStr, out double Longitude))
                                {
                                    Console.WriteLine("The character entered is invalid.");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Enter Description");
                                    string Description = Console.ReadLine();
                                    //Report newReport = new DroneReport(reportId, Timestamp, Latitude, Longitude, Altitude, )
                                }
                            }
                        }
                    }
                    
                }
            }
            
        }
        Report report1 = new DroneReport(1, DateTime.Parse("2026-06-29 14:30:01"), 31.000, 34.5000, "A spy films Shivata", 1000, 70);
        args = new string[] { "report1" };
        //Console.WriteLine(report1.Timestamp);
    }
    private static void DisplayReport(Report report)
    {

    }
}