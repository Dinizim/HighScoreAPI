using HighScoreAPI.Domain.Validation.notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.OperationResult;
public class OperationResult
{
    private List<string> Errors;

    public OperationResult(bool success, string message)
    {
        Success = success;
        Message = message;
        Errors = new List<string>();
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public IReadOnlyCollection<string> _errors => Errors;
    

    public void SetErrors(string errors)
    {
        Errors.Add(errors);
    }
}
