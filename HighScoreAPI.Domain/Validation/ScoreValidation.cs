using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighScoreAPI.Domain.Validation.notification;

namespace HighScoreAPI.Domain.Validation;
public partial class ContractValidations<T>
{
    public ContractValidations<T> ScoreNoTNegativeOK(double score, string message, string propertyName)
    {
        if (score < 0)
            AddNotification(new Notification(message, propertyName));

        return this;
    }
    public ContractValidations<T> ScoreRelationshipIsValidOK(double score, string message, string propertyName)
    {
        throw new NotImplementedException();
    }
}
