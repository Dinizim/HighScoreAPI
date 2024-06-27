using HighScoreAPI.Domain.Validation.notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.Result;
public class OperationResult
{
    private List<string> Errors;

    public OperationResult(int statusCode, bool success, string message)
    {
        StatusCode = statusCode;
        Success = success;
        Message = message;
        Errors = new List<string>();
    }

    public int StatusCode { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public IReadOnlyCollection<string> _errors => Errors;
    

    public void SetErrors(string errors)
    {
        Errors.Add(errors);
    }
}
