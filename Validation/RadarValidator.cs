using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Validation;

class RadarValidator : BaseValidator
{
    protected override ValidationResult ValidateSpecificFields(Report report)///Specific Fields Check Function.
    {
        var radarReport = report as RadarReport;
        if (typeof(RadarReport) != report.GetType())
        {
            return ValidationResult.Failure("Invalid report type. Must be: RadarReport");
        }
        if(radarReport.Speed < 0 || radarReport.Speed > 2000)
        {
            return ValidationResult.Failure("Invalid Speed: Must be between 0 and 2000");
        }
        if(radarReport.Direction < 0 || radarReport.Direction > 360)
        {
            return ValidationResult.Failure("Invalid Direction: Must be between 0 and 360");
        }
        if(radarReport.Distance < 100 ||  radarReport.Distance > 100000)
        {
            return ValidationResult.Failure("Invalid Distance: Must be between 100 and 100000");
        }
        return ValidationResult.Success();
    }
}