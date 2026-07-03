using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Validation;

class SoldierValidator : BaseValidator
{
    protected override ValidationResult ValidateSpecificFields(Report report)///Specific Fields Check Function
    {
        var soldierReport = report as SoldierReport;
        if (typeof(SoldierReport) != report.GetType())
        {
            return ValidationResult.Failure("Invalid report type. Must be: SoldierReport");
        }
        else if(string.IsNullOrEmpty(soldierReport.SoldierName))
        {
            return ValidationResult.Failure("Missing required field: SoldierName");
        }    
        else if(soldierReport.SoldierName.Length < 2 || soldierReport.SoldierName.Length > 50)
        {
            return ValidationResult.Failure("Invalid SoldierName: Must be between 2 and 50 characters");
        }
        else if (string.IsNullOrEmpty(soldierReport.SoldierID))
        {
            return ValidationResult.Failure("Missing required field: SoldierID");
        }
        else if(soldierReport.SoldierID.Length != 7)
        {
            return ValidationResult.Failure("Invalid SoldierID: Must be 7 digits");
        }
        else if (string.IsNullOrEmpty(soldierReport.Unit))
        {
            return ValidationResult.Failure("Missing required field: Unit");
        }
        else if (soldierReport.Unit.Length < 2 || soldierReport.Unit.Length > 50)
        {
            return ValidationResult.Failure("Invalid Unit: Must be between 2 and 50 characters");
        }
        else if (soldierReport.ConfidenceLevel < 1 || soldierReport.ConfidenceLevel > 5)
        {
            return ValidationResult.Failure("Invalid ConfidenceLevel: Must be between 1 and 5");
        }
        return ValidationResult.Success();
    }
}