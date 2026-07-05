using IntelligencePipeline.Models.Enums;
using System;
using System.Reflection.Metadata;
namespace IntelligencePipeline.Models.Reports;

class SoldierReport : Report
{
    public string SoldierName { get; protected set; }
    public string SoldierID { get; protected set; }
    public string Unit { get; protected set; }
    public int ConfidenceLevel { get; protected set; }
    public SoldierReport(int reportId, DateTime timestamp, double latitude, double longitude, string description, string soldierName, string soldierID, string unit, int confidenceLevel)
        : base(reportId, timestamp, latitude, longitude, description)
    {
        SoldierName = soldierName;
        SoldierID = soldierID;
        Unit = unit;
        ConfidenceLevel = confidenceLevel;
    }
    public override string GetSourceType() => "Soldier";
    public override int CalculateReliabilityScore()
    {
        int ReliabilityScore = 4;
        ReliabilityScore += ConfidenceLevel;
        if (Description.ToLower().Contains("weapon")
            || Description.ToLower().Contains("vehicle")
            || Description.ToLower().Contains("movement")
            || Description.ToLower().Contains("explosion")) ReliabilityScore += 1;
        return ReliabilityScore;
    }
    public override string ToString()
    {
        return $"id: {ReportId}, time: {Timestamp}, latitude: {Latitude}, longitude: {Longitude}, description: {Description}, soldier Name: {SoldierName}, soldier ID: {SoldierID}, unit: {Unit}, confidence level: {ConfidenceLevel}, status: {Status}, classification: {Classification}, priority: {Priority}";
    }
}