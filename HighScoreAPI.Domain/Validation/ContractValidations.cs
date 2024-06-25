using HighScoreAPI.Domain.Validation.Interfaces;
using HighScoreAPI.Domain.Validation.notification;

namespace HighScoreAPI.Domain.Validation;

public partial class ContractValidations<T> where T : IContract
{
    private List<Notification> _notifications;

    public ContractValidations()
    {
        _notifications = new List<Notification>();
    }

    public IReadOnlyCollection<Notification> Notifications => _notifications;

    public void AddNotification(Notification notification)
    {
        _notifications.Add(notification);
    }

    public bool IsValid()
    {
        return _notifications.Count == 0;
    }
}