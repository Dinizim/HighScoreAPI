using HighScoreAPI.Domain.Validation.notification;

namespace HighScoreAPI.Domain.Models;

public abstract class BaseEntity
{
    private List<Notification> _notifications;

    public int Id { get; }
    public IReadOnlyCollection<Notification> Notifications => _notifications;

    protected void SetNotification(List<Notification> notifications)
    {
        _notifications = notifications;
    }

    public abstract bool Validation();
}