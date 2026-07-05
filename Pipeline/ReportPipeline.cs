using IntelligencePipeline.Calculators;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;
using System;
namespace IntelligencePipeline.Pipeline;
class ReportPipeline
{
    private ReportRepository _validatedReports;
    private RejectedReportRepository _rejectedReports;
    private readonly ReliabilityCalculator _reliabilityCalculator;
    private readonly PriorityCalculator _priorityCalculator;
    private readonly ClassificationCalculator _classificationCalculator;
    private int _nextReportId;
    public ReportPipeline()
    {
        _validatedReports = new ReportRepository();
        _rejectedReports = new RejectedReportRepository();
        _reliabilityCalculator = new ReliabilityCalculator();
        _priorityCalculator = new PriorityCalculator();
        _classificationCalculator = new ClassificationCalculator();
        _nextReportId = 1;
    }
    public void ProcessReport(Report report)
    {
        report.Status = ReportStatus.Validating;
        report.ReportId = _nextReportId++;
        ValidateReport(report);
    }
    public ReportRepository GetValidatedReports()
    {
        var reports = _validatedReports.GetAll();
        Console.WriteLine("=== Validated reports ===");
        for(int i = 0;  i < _validatedReports.GetTotalCount(); i++)
        {
            Console.WriteLine(reports[i].ToString());
        }
        Console.WriteLine("=========================");
        return _validatedReports;
    }
    public RejectedReportRepository GetRejectedReports()
    {
        var reports = _rejectedReports.GetAll();
        {
            Console.WriteLine("=== Rejected reports ===");
            for (int i = 0; i < _rejectedReports.GetTotalCount(); i++)
            {
                Console.WriteLine(reports[i].ToString());
            }
        }
        Console.WriteLine("=========================");
        return _rejectedReports;
    }
    public void DisplayStatistics()
    {

    }
    private IValidator GetValidator(Report report)
    {
        if (report is DroneReport)
            return new DroneValidator();
        if (report is SoldierReport)
            return new SoldierValidator();
        if (report is RadarReport)
            return new RadarValidator();
        return new SignalValidator();
    }
    private void ValidateReport(Report report)
    {
        IValidator validator = GetValidator(report);
        var result = validator.Validate(report);
        Console.WriteLine("The report has been received! Moving on to data verification...");
        if (result.IsValid)
        { 
            CalculateMetrics(report);
            report.Status = ReportStatus.Validated;
            _validatedReports.Add(report);
            Console.WriteLine("The data is correct!");
            GetValidatedReports();
        }
        else
        {
            report.Status = ReportStatus.Rejected;
            _rejectedReports.Add(report);
            Console.WriteLine("The data is incorrect!");
            report.RejectionReason = result.ErrorMessage;
            GetRejectedReports();
        }
    }
    private void CalculateMetrics(Report report)
    {

        var reliability =  _reliabilityCalculator.Calculate(report);
        var priority = _priorityCalculator.Calculate(report);
        var classification = _classificationCalculator.Calculate(report);

        report.ReliabilityScore = reliability;
        report.Priority = priority;
        report.Classification = classification;
    }
    private void StoreReport(Report report)
    {

    }
    public int GetValidatedCount()
    {
        return _validatedReports.GetTotalCount();
    }

    public int GetRejectedCount()
    {
        return _rejectedReports.GetTotalCount();
    }
}