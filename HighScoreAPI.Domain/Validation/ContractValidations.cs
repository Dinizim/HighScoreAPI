using HighScoreAPI.Domain.Validation.Interfaces;
using HighScoreAPI.Domain.Validation.notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Domain.Validation;

public partial class ContractValidations<T> where T : IContract
{
    private List<Notification> _notifications;

    public ContractValidations(List<Notification> notifications)
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