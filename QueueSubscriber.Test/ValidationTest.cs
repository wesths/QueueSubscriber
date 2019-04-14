using QueueSubscriber.Interface.Contracts;
using QueueSubscriber.Service.Services;
using System;
using Xunit;

namespace QueueSubscriber.Test
{
    public class ValidationTest
    {
        private readonly IValidationService _validationService;

        public ValidationTest()
        {
            _validationService = new ValidationService();
        }

        [Fact]
        public void MessageConsumedHasCorrectFormatPositive()
        {
            string messageToBeConsumed = "Hello my name is, Shane";

            string result = _validationService.ValidateName(messageToBeConsumed);

            Assert.Equal("Hello Shane, I am your father!", result);

        }
        [Fact]
        public void MessageConsumedHasCorrectFormatNegative()
        {
            string messageToBeConsumed = "This string is incorrect";

            string result = _validationService.ValidateName(messageToBeConsumed);

            Assert.Equal("The name you entered is incorrect", result);

        }
        [Fact]
        public void MessageConsumedHasAValuePositivee()
        {
            string messageToBeConsumed = "Hello my name is, ";

            string result = _validationService.ValidateName(messageToBeConsumed);

            Assert.Equal("Please ensure you enter a name", result);

        }
    }
}
