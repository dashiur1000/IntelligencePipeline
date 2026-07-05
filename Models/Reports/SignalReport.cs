using IntelligencePipeline.Models.Enums;
using System;
using System.Reflection.Metadata;
namespace IntelligencePipeline.Models.Reports;

class SignalReport : Report
{
    int LowSignalStrength = -70;
    int HighSignalStrength = -40;
    int VeryHighSignalStrength = -100;
    public double Frequency { get; protected set; }
    public string Content { get; protected set; }
    public Language Language { get; protected set; }
    public int SignalStrength { get; protected set; }
    public SignalReport(int reportId, DateTime timestamp, double latitude, double longitude, string description, double frequency, string content, Language language, int signalStrength)
        : base(reportId, timestamp, latitude, longitude, description)
    {
        Frequency = frequency;
        Content = content;
        Language = language;
        SignalStrength = signalStrength;
    }
    public override string GetSourceType() => "Signal";
    public override int CalculateReliabilityScore()
    {
        int ReliabilityScore = 5;
        if (SignalStrength >= HighSignalStrength) ReliabilityScore += 3;
        if (SignalStrength >= LowSignalStrength && SignalStrength < HighSignalStrength) ReliabilityScore += 2;
        if(Content.ToLower().Contains("attack")
            || Content.ToLower().Contains("target")
            || Content.ToLower().Contains("border")
            || Content.ToLower().Contains("vehicle")) ReliabilityScore += 1;
        if (SignalStrength < VeryHighSignalStrength) ReliabilityScore -= 2;
        return ReliabilityScore;

    }
    public override string ToString()
    {
        return $"id: {ReportId}, time: {Timestamp}, latitude: {Latitude}, longitude: {Longitude}, description: {Description}, frequency: {Frequency}, content: {Content}, language: {Language}, signalStrength: {SignalStrength}, status: {Status}, classification: {Classification}, priority: {Priority}";
    }
}