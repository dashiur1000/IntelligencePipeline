using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Calculators;
class ClassificationCalculator
{
    public Classification Calculate(Report report)
    {
        //TopSecret
        if (report.Priority == Priority.Critical) return Classification.TopSecret;
        else if (report is SignalReport signalReport1 && ContainsKeyword(signalReport1.Content, TopSecret)) return Classification.TopSecret;
        //Secret
        else if (report.Priority == Priority.High) return Classification.Secret;
        else if (report is SignalReport signalReport2) return Classification.Secret;
        else if (ContainsKeyword(report.Description, Secret)) return Classification.Secret;
        //Restricted
        else if (report.Priority == Priority.Medium) return Classification.Restricted;
        else if (report is SoldierReport soldierReport) return Classification.Restricted;
        return Classification.Unclassified;
    }
    string[] TopSecret = { "target", "attack", "missile" };
    string[] Secret = { "weapon", "border" };
    private bool ContainsKeyword(string text, params string[] keywords)
    {
        for (int i = 0; i < keywords.Length; i++)
            if (text.ToLower().Contains(keywords[i])) return true;
        return false;
    }
}