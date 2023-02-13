using DwitTech.AccountService.Core.Interfaces;
using DwitTech.AccountService.Core.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Core.Services
{
    public class ActivationService : IActivationService
    {
        private static string GetActivationCode()
        {
            var activationCode = RandomUtil.GenerateUniqueCode();
            return activationCode;
        }

        private string GetNameFromDb(string userEmail) //TODO
        {
            return "Mike";
        }

        private static string GetBaseUrl() //TODO
        {
            return "Test.com";
        }

        private static string GetActivationUrl()
        {
            string baseUrl = GetBaseUrl();
            string activationCode = GetActivationCode();
            string activationUrl = baseUrl + "/Account/Activation/" + activationCode;
            return activationUrl;
        }

        private static bool SendMail(string fromEmail, string toEmail, string subject, string body, string cc = "", string bcc = "") //TODO
        {
            return true;
        }

        public bool SendActivationEmail(string fromEmail, string toEmail, string templateName, string subject = "Account Activation", string cc = "", string bcc = "")
        {
            var baseUrl = GetBaseUrl();
            var activationUrl = GetActivationUrl();
            var RecipientName = GetNameFromDb(toEmail);
            string trimmedTemplateName = templateName.Trim();
            string filePath = "Templates/" + trimmedTemplateName;
            StreamReader str = new StreamReader(filePath);
            var readTemplateText = str.ReadToEnd();
            str.Close();
            readTemplateText = readTemplateText.Replace("{{name}}", RecipientName) ;
            readTemplateText = readTemplateText.Replace("{{activationUrl}}", activationUrl);
            string body = readTemplateText.ToString();
            var response = SendMail(fromEmail, toEmail, subject, body, cc, bcc);

            return response;
        }
    }
}