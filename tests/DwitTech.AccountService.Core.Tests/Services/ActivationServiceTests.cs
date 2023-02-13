using DwitTech.AccountService.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Core.Tests.Services
{
    public class ActivationServiceTests
    {
        [Theory]
        [InlineData("testcase@gmail.com", "example@gmail.com", "EmailTemplate.html", true)]
        public void SendActivationEmail_Returns_True(string fromMail, string toMail, string templateName, bool expected)
        {
            //Arrange
            var actService = new ActivationService();

            //Act
            var actual = actService.SendActivationEmail(fromMail, toMail, templateName);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
