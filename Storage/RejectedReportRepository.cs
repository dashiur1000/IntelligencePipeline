using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Storage;
class RejectedReportRepository
{
    private List<Report> _rejectedReports;
    public RejectedReportRepository()
    {
        _rejectedReports = new List<Report>();
    }
    public void Add(Report report)
    {
        _rejectedReports.Add(report);
    }
    public List<Report> GetAll()
    {
        return _rejectedReports;
    }
    public int GetTotalCount()
    {
        return (_rejectedReports.Count);
    }
    public List<Report> GetByReason(string reasonKeyword)
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