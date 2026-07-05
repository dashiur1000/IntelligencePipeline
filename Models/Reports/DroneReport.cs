using System;
namespace IntelligencePipeline.Models.Reports;

class DroneReport : Report
{
    int HighQuality = 80;
    int LowQuality = 50;
    int HighAltitude = 7000;
    int StandardAltitude = 3000;
    int LowAltitude = 500;
    public int Altitude { get; protected set; }
    public int ImageQuality { get; protected set; }

    public DroneReport(int reportId, DateTime timestamp, double latitude, double longitude, string description, int altitude, int imageQuality)
        : base(reportId, timestamp, latitude, longitude, description)
    {
        Altitude = altitude;
        ImageQuality = imageQuality;
    }
    public override string GetSourceType() => "Drone";
    public override int CalculateReliabilityScore()
    {
        int ReliabilityScore = 5;
        if (ImageQuality >= HighQuality) ReliabilityScore += 3;
        if (ImageQuality >= LowQuality && ImageQuality < HighQuality) ReliabilityScore += 2;
        if (Altitude >= LowAltitude && Altitude <= StandardAltitude) ReliabilityScore += 2;
        if(Altitude > HighAltitude) ReliabilityScore -= 2;
        return ReliabilityScore;
    }
    public override string ToString()
    {
        return $"id: {ReportId}, time: {Timestamp}, latitude: {Latitude}, longitude: {Longitude}, description: {Description}, altitude: {Altitude}, imageQuality: {ImageQuality}, status: {Status}, classification: {Classification}, priority: {Priority}";
    }
}