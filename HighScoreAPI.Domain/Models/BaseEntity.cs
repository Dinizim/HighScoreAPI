using HighScoreAPI.Domain.Repositories;
using HighScoreAPI.Domain.Validation.notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
