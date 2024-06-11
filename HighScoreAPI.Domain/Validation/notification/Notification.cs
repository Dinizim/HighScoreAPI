using HighScoreAPI.Domain.Validation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Domain.Validation.notification;
public class Notification : Inotification
{
    public Notification(string message, string propertyName)
    {
        Message = message;
        PropertyName = propertyName;
    }

    public string Message { get; private set; }
    public string PropertyName { get; private set; }
}
