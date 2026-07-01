using System;
using IntelligencePipeline.Storage;
namespace IntelligencePipeline.Pipeline;
class ReportPipeline
{
    private ReportRepository _validatedReports;
    private RejectedReportRepository _rejectedReports;
    private int _nextReportId;
}