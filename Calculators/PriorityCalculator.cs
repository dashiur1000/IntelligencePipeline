using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
using System.Reflection;
namespace IntelligencePipeline.Calculators;
class PriorityCalculator
{
    public Priority Calculate(Report report)
    {
        //Critical
        if(ContainsKeyword(report.Description, Critical)) return Priority.Critical;
        else if(report is SignalReport signalReport)
        {
            if(ContainsKeyword(signalReport.Content, Critical)) return Priority.Critical;
        }
        else if(report is RadarReport radarReport1 && radarReport1.Speed >= 800) return Priority.Critical;
        //High
        else if(ContainsKeyword(report.Description, High)) return Priority.High;
        else if(report is DroneReport droneReport && droneReport.Altitude < 500) return Priority.High;
        else if(report is RadarReport radarReport2 && radarReport2.Speed >= 400) return Priority.High;
        else if(report is SoldierReport soldierReport && soldierReport.ConfidenceLevel >= 4 && soldierReport.Description.ToLower().Contains("movement")) return Priority.High;
        //Medium
        else if (ContainsKeyword(report.Description, Medium)) return Priority.Medium;
        else if (report is RadarReport radarReport3 && radarReport3.Speed >= 120) return Priority.Medium;
        else if(report.ReliabilityScore >= 7) return Priority.Medium;
        
        //Low
        return Priority.Low;
    }
    string[] Critical = { "fire", "explosion", "attack", "missile" };
    string[] High = { "border", "suspicious", "weapon" };
    string[] Medium = { "activity", "vehicle", "movement" };
    private bool ContainsKeyword(string text, params string[] keywords)
    {
        for(int i = 0; i < keywords.Length; i++)
            if(text.ToLower().Contains(keywords[i])) return true;
        return false;
    }
}