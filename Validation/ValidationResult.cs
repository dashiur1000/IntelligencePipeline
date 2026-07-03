using System;
namespace IntelligencePipeline.Validation;
class ValidationResult///A class that creates objects of a valid or invalid message.
{
    private bool _isValid;
    private string _errorMessage;
    public bool IsValid
    {
        get { return _isValid; }
    }
    public string ErrorMessage
    {
        get { return _errorMessage; }
    }

    public ValidationResult(bool isValid, string errorMessage)///constructor
    {
        _isValid = isValid;
        _errorMessage = errorMessage;
    }
    public static ValidationResult Success()///If there is no error
    {
        return new ValidationResult(true, string.Empty);
    }
    public static ValidationResult Failure(string errorMessage)///If there is an error - creates an object with the message
    {
        return new ValidationResult(false, errorMessage);
    }
}