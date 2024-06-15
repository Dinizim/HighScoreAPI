﻿using HighScoreAPI.Domain.Validation.notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Domain.Validation;
public partial class ContractValidations<T>
{

    public ContractValidations<T> NameNotEmptyOK(string name, short maxlenght, string message, string propertyName)
    {
        if(string.IsNullOrEmpty(name) || name.Length > maxlenght)
            AddNotification(new Notification(message, propertyName));

        return this;
    }
}
