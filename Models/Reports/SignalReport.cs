using IntelligencePipeline.Models.Enums;
using System;
namespace IntelligencePipeline.Models.Reports;

class SignalReport : Report
{
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
        if (SignalStrength >= -40) ReliabilityScore += 3;
        if (SignalStrength >= -70 && SignalStrength < -40) ReliabilityScore += 2;
        if(Content.ToLower().Contains("attack")
            || Content.ToLower().Contains("target")
            || Content.ToLower().Contains("border")
            || Content.ToLower().Contains("vehicle")) ReliabilityScore += 1;
        if (SignalStrength < -100) ReliabilityScore -= 2;
        return ReliabilityScore;

    }
}