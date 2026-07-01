using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Storage;

class ReportRepository
{
    private List<Report> _reports;
    public ReportRepository()
    {
        _reports = new List<Report>();
    }
    public void Add(Report report)
    {
        _reports.Add(report);
    }
    public List<Report> GetAll()
    {
        return _reports;
    }
    public List<Report> GetByStatus(ReportStatus status)
    {
        List<Report> result = new List<Report>();
        for (int i = 0; i < _reports.Count; i++)
        {
            if (_reports[i].Status == status)
                result.Add(_reports[i]);
        }
        return result;
    }
    public List<Report> GetByPriority(Priority priority)
    {
        List<Report> result = new List<Report>();
        for (int i = 0; i < _reports.Count; i++)
        {
            if( _reports[i].Priority == priority)
                result.Add(_reports[i]);
        }
        return result;
    }
    public List<Report> Search(string keyword)
    {
        List<Report> result = new List<Report>();
        for (int i = 0; i < _reports.Count; i++)
        {
            if (_reports[i].Description.ToLower().Contains(keyword.ToLower()))
                result.Add(_reports[i]);
        }
        return result;
    }
    public Report GetById(int reportId)
    {
        for (int i = 0; i < _reports.Count; i++)
        {
            if (_reports[i].ReportId == reportId)
                return _reports[i];
        }
        return null;
    }
    public void UpdateStatus(int reportId, ReportStatus newStatus)
    {
        for (int i = 0; i < _reports.Count; i++)
        {
            if (_reports[i].ReportId == reportId)
                _reports[i].Status = newStatus;
        }
    }
    public int GetTotalCount()
    {
        return _reports.Count;
    }
    public int GetCountByStatus(ReportStatus status)
    {
        int counter = 0;
        for(int i = 0; i < _reports.Count;i++)
        {
            if(status == _reports[i].Status)
                counter++;
        }
        return counter;
    }

}