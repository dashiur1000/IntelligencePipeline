using IntelligencePipeline.Models.Enums;
using System;
namespace IntelligencePipeline;
abstract class Report
{
    private DateTime minDate = new DateTime(2020, 1, 1);
    private int _reportId;
    private DateTime _timestamp;
    private double _latitude;
    private double _longitude;
    private string _description;
    private ReportStatus _status;
    private Priority _priority;
    private Classification _classification;
    private int _reliabilityScore;
    private string _rejectionReason;


    public int ReportId { get; }
    public DateTime Timestamp
    {
        get => _timestamp;
        set
        {
            if (value > DateTime.Now)
            {
                Status = ReportStatus.Rejected;
                RejectionReason = "Invalid Timestamp: cannot be in the future";
            }
            else if (value < minDate)
            {
                Status = ReportStatus.Rejected;
                RejectionReason = $"Invalid Timestamp: must be between {minDate:yyyy-MM-dd} and {DateTime.Now:yyyy-MM-dd}";
            }
            else
                _timestamp = value;
        }
    }
    public double Latitude
    {
        get => _latitude;
        set
        {
            if(_latitude < 29.5000 || _latitude > 33.5000)
            {
                Status = ReportStatus.Rejected;
                RejectionReason = $"Invalid latitude: must be between 29.5000 and 33.5000";
            }
            else
                _latitude = value;
        }
    }
    public double Longitude
    {
        get => _longitude;
        set
        {
            if(_longitude < 34.0000 || _longitude > 36.0000)
            {
                Status = ReportStatus.Rejected;
                RejectionReason = $"Invalid longitude: must be between 34.0000 and 36.0000";
            }
            else
                _longitude = value;
        }
    }
    public string Description
    {
        get => _description;
        set
        {
            if(value.Length < 10 || value.Length > 100)
            {
                Status = ReportStatus.Rejected;
                RejectionReason = $"Invalid description: must be between 10 and 500 characters";
            }
            else
                _description = value;
        }
    }
    public  ReportStatus Status { get; set; }
    public Priority Priority { get; set; }
    public Classification Classification { get; set; }
    public int ReliabilityScore { get; set; }
    public string RejectionReason { get; set; }

}