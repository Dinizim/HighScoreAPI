﻿using HighScoreAPI.Domain.Validation.Interfaces;

namespace HighScoreAPI.Domain.Validation.notification;

public class Notification : INotification
{
    public Notification(string message, string propertyName)
    {
        Message = message;
        PropertyName = propertyName;
    }

    public string Message { get; private set; }
    public string PropertyName { get; private set; }
}