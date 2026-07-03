using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Storage;
class RejectedReportRepository
{
    private List<Report> _rejectedReports;///Creates a list of incorrect reports
    public RejectedReportRepository()///Initialize a list
    {
        _rejectedReports = new List<Report>();
    }
    public void Add(Report report)///Add to a list
    {
        _rejectedReports.Add(report);
    }
    public List<Report> GetAll()///Return the entire list
    {
        return _rejectedReports;
    }
    public int GetTotalCount()///Return the number of reports
    {
        return (_rejectedReports.Count);
    }
    public List<Report> GetByReason(string reasonKeyword)///Returns a report with a specific word in the rejection message.
    {
        List<Report> result = new List<Report>();
        for (int i = 0;  i < _rejectedReports.Count; i++ )
        {
            if (_rejectedReports[i].RejectionReason.Contains(reasonKeyword))
                result.Add( _rejectedReports[i] );
        }
        return result;
    }
}