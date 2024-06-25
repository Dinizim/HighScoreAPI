using HighScoreAPI.Domain.Validation.notification;

namespace HighScoreAPI.Domain.Validation;

public partial class ContractValidations<T>
{
    public ContractValidations<T> NameNotEmptyOK(string name, short maxlenght, string message, string propertyName)
    {
        if (string.IsNullOrEmpty(name) || name.Length > maxlenght)
            AddNotification(new Notification(message, propertyName));

        return this;
    }

    public ContractValidations<T> NameIsUniqueOK(string name, short maxlenght, string message, string propertyName)
    {
        throw new NotImplementedException();
    }
}