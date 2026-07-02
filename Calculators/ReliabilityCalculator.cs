using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Calculators;
class ReliabilityCalculator
{
    public int Calculate(Report report)
    {
        int score = report.CalculateReliabilityScore();
        if(score < 1)
            return score = 1;
        if (score > 10)
            return score = 10;
        else
            return score;
    }
}