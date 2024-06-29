using HighScoreAPI.Domain.Validation.notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.Result;
public class OperationResult
{
    private List<string> _errors;

    public OperationResult(int statusCode, bool success, string message)
    {
        StatusCode = statusCode;
        Success = success;
        Message = message;
        _errors = new List<string>();
    }

    public int StatusCode { get; private set; }
    public bool Success { get; private set; }
    public string Message { get; private set; }
    public object Data { get; set; }

    public IReadOnlyCollection<string> Errors => _errors;

    public void SetErrors(string errors)
    {
        _errors.Add(errors);
    }


}
