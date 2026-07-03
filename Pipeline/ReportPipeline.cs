using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;
using System;
namespace IntelligencePipeline.Pipeline;
class ReportPipeline
{
    private ReportRepository _validatedReports;
    private RejectedReportRepository _rejectedReports;
    private int _nextReportId;
    public ReportPipeline()
    {
        _validatedReports = new ReportRepository();
        _rejectedReports = new RejectedReportRepository();
        int NextReportId = _nextReportId;
    }
    public void ProcessReport(Report report)
    {
        report.Status = ReportStatus.Validating;
        IValidator validator = GetValidator(report);
        

        report.Status = ReportStatus.Validated;

    }
    public ReportRepository GetValidatedReports()
    {
        return _validatedReports;
    }
    public RejectedReportRepository GetRejectedReports()
    {
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

    }
    private void CalculateMetrics(Report report)
    {

    }
    private void StoreReport(Report report)
    {

    }
}