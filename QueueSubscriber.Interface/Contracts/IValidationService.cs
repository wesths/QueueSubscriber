using System;
using System.Collections.Generic;
using System.Text;

namespace QueueSubscriber.Interface.Contracts
{
    public interface IValidationService
    {
        string ValidateMessage(string message);
    }
}
