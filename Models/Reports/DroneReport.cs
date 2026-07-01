using System;
namespace IntelligencePipeline.Models.Reports;

class DroneReport : Report
{
    public int Altitude { get; protected set; }
    public int ImageQuality { get; protected set; }

    public DroneReport(DateTime timestamp, double latitude, double longitude, string description, int altitude, int imageQuality)
        : base(timestamp, latitude, longitude, description)
    {
        Altitude = altitude;
        ImageQuality = imageQuality;
    }
    public override string GetSourceType() => "Drone";
    public override int CalculateReliabilityScore()
    {
        int ReliabilityScore = 5;
        if (ImageQuality >= 80) ReliabilityScore += 3;
        if (ImageQuality >= 50 && ImageQuality < 80) ReliabilityScore += 2;
        if (Altitude >= 500 && Altitude <= 3000) ReliabilityScore += 2;
        if(Altitude > 7000) ReliabilityScore -= 2;
        return ReliabilityScore;
    }

}