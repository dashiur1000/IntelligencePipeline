using IntelligencePipeline.Models.Enums;
using System;
namespace IntelligencePipeline.Models.Reports;

class RadarReport : Report
{
    int LowDistance = 500;
    int HighDistance = 30000;
    int VeryHighDistance = 70000;
    int LowSpeed = 10;
    int HighSpeed = 1500;
    int StandardSpeed = 900;
    public int Speed { get; protected set; }
    public int Direction { get; protected set; }
    public int Distance { get; protected set; }
    public RadarReport(int reportId, DateTime timestamp, double latitude, double longitude, string description, int speed, int direction, int distance)
        : base(reportId, timestamp, latitude, longitude, description)
    {
        Speed = speed;
        Direction = direction;
        Distance = distance;
    }
    public override string GetSourceType() => "Radar";
    public override int CalculateReliabilityScore()
    {
        int ReliabilityScore = 6;
        if(Distance >= LowDistance && Distance <= HighDistance) ReliabilityScore += 2;
        if (Speed >= LowSpeed && Speed <= StandardSpeed) ReliabilityScore += 1;
        if(Distance > VeryHighDistance) ReliabilityScore -= 2;
        if (Speed > HighSpeed) ReliabilityScore -= 2;
        return ReliabilityScore;
    }
    public override string ToString()
    {
        return $"id: {ReportId}, time: {Timestamp}, latitude: {Latitude}, longitude: {Longitude}, description: {Description}, speed: {Speed}, direction: {Direction}, distance: {Distance}, status: {Status}, classification: {Classification}, priority: {Priority}";
    }
}