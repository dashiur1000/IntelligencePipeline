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
                                    string description = Console.ReadLine();
                                    Console.WriteLine("Enter Altitude");
                                    string altitudeStr = Console.ReadLine();
                                    if(!int.TryParse(altitudeStr, out int altitude))
                                    {
                                        Console.WriteLine("The character entered is invalid.");
                                        continue;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter ImageQuality");
                                        string imageQualityStr = Console.ReadLine();
                                        if(!int.TryParse(imageQualityStr, out int imageQuality))
                                        {
                                            Console.WriteLine("The character entered is invalid.");
                                            continue;
                                        }
                                        else
                                        {
                                            Report newReport = new DroneReport(Timestamp, Latitude, Longitude, description, altitude, imageQuality);
                                            Console.WriteLine(newReport.Timestamp);
                                        }
                                    }
                                        

                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
            
        
        
    
    private static void DisplayReport(Report report)
    {

    }
}