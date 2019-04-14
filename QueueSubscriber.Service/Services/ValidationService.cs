using QueueSubscriber.Interface.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueSubscriber.Service.Services
{
    public class ValidationService : IValidationService
    {
        public ValidationService()
        {
        }

        public string ValidateName(string message)
        {
            if(message.StartsWith("Hello my name is, "))
            {
                var name = message.Split(',').Last().Trim();
                if(string.IsNullOrEmpty(name))
                {
                    return "Please ensure you enter a name";
                }
                return $"Hello {name}, I am your father!";
            }
            return "The name you entered is incorrect";
        }
    }
}
