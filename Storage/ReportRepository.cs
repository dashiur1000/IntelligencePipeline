using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Storage;

class ReportRepository
{
    private List<Report> _reports;///Create a list of reports
    public ReportRepository()///Initialize a list
    {
        _reports = new List<Report>();
    }
    public void Add(Report report)///Add to a list
    {
        _reports.Add(report);
    }
    public List<Report> GetAll()///Return the entire list
    {
        return _reports;
    }
    public List<Report> GetByStatus(ReportStatus status)///Return by a specific status
    {
        List<Report> result = new List<Report>();
        for (int i = 0; i < _reports.Count; i++)
        {
            if (_reports[i].Status == status)
                result.Add(_reports[i]);
        }
        return result;
    }
    public List<Report> GetByPriority(Priority priority)///Return by a specific priority
    {
        List<Report> result = new List<Report>();
        for (int i = 0; i < _reports.Count; i++)
        {
            if( _reports[i].Priority == priority)
                result.Add(_reports[i]);
        }
        return result;
    }
    public List<Report> GetByClassification(Classification classification)///Return by a specific priority
    {
        List<Report> result = new List<Report>();
        for (int i = 0; i < _reports.Count; i++)
        {
            if (_reports[i].Classification == classification)
                result.Add(_reports[i]);
        }
        return result;
    }
    public List<Report> Search(string keyword)///Return a report containing a specific word
    {
        List<Report> result = new List<Report>();
        
            foreach(var report in _reports)
            {
                if(report.Description.ToLower().Contains(keyword.ToLower()))
                {
                    result.Add(report);
                }
        }
        return result;
    }
    public Report GetById(int reportId)///Return by a specific ID
    {
        for (int i = 0; i < _reports.Count; i++)
        {
            if (_reports[i].ReportId == reportId)
                return _reports[i];
        }
        return null;
    }
    public void UpdateStatus(int reportId, ReportStatus newStatus)///Update status by ID
    {
        for (int i = 0; i < _reports.Count; i++)
        {
            if (_reports[i].ReportId == reportId)
                _reports[i].Status = newStatus;
        }
    }
    public int GetTotalCount()///Return the number of reports
    {
        return _reports.Count;
    }
    public int GetCountByStatus(ReportStatus status)///Return reports by a specific status
    {
        int counter = 0;
        for(int i = 0; i < _reports.Count;i++)
        {
            if(status == _reports[i].Status)
                counter++;
        }
        return counter;
    }
    public List<Report> GetBySourceType(string type)
    {
        List<Report> result = new List<Report>();
        string searchType = type.ToLower();

        foreach (var report in _reports)
        {
            if (report.GetType().Name.ToLower().Contains(searchType))
            {
                result.Add(report);
            }
        }
        return result;
    }
    public List<Report> GetByDate(DateTime first, DateTime second)
    {
        List<Report> result = new List<Report>();
        foreach (var report in _reports)
        {
            if (report.Timestamp > first && report.Timestamp < second)
            {
                result.Add(report);
            }
        }
        return result;
    }

}