using HighScoreAPI.Application.Output.Results.Interfaces;
using HighScoreAPI.Domain.Validation.notification;

namespace HighScoreAPI.Application.Output.Results;

public class Result : IResultBase
{
    private List<Notification> _notifications;

    public Result(int statusCode, string message, bool isOk)
    {
        StatusCode = statusCode;
        Message = message;
        IsOk = isOk;
        _notifications = new List<Notification>();
    }

    public int StatusCode { get; private set; }
    public string Message { get; private set; }
    public bool IsOk { get; private set; }
    public object Data { get; private set; }
    public IReadOnlyCollection<Notification> Notifications => _notifications;

    public void SetNotifications(List<Notification> notifications)
    {
        _notifications = notifications;
    }

    public void SetData(object data)
    {
        Data = data;
    }
}