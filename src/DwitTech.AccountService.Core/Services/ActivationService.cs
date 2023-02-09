using DwitTech.AccountService.Core.Interfaces;
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
        private string GetActivationCodeFromDb(string userEmail)
        {
            return "pttigkgkgkgkgk6666k6k6k6k6k6k6k1123ndncj";
        }

        private string GetNameFromDb(string userEmail)
        {
            return "Mike";
        }

        private static string GetBaseUrl()
        {
            return "Test.com";
        }

        private string GetActivationUrl(string userEmail)
        {
            string baseUrl = GetBaseUrl();
            string activationCode = GetActivationCodeFromDb(userEmail);
            string activationUrl = baseUrl + "/TestAppName/ActivateAccount/" + activationCode;
            return activationUrl;
        }

        private bool SendMail(string from, string to, string subject, string body, string cc = "", string bcc = "")
        {
            return true;
        }

        public bool SendActivationEmail(string from, string userEmail, string templateName, string subject = "Account Activation")
        {
            string userActivationCode = GetActivationCodeFromDb("example@gmail.com");
            var baseUrl = GetBaseUrl();
            var activationUrl = GetActivationUrl(userEmail);
            var RecipientName = GetNameFromDb(userEmail);
            string filePath = "Templates\\" + templateName;
            StreamReader str = new StreamReader(filePath);
            var readTemplateText = str.ReadToEnd();
            str.Close();
            readTemplateText = readTemplateText.Replace("{{name}}", RecipientName) ;
            readTemplateText = readTemplateText.Replace("{{activationUrl}}", activationUrl);
            string body = readTemplateText.ToString();
            var response = SendMail(from, userEmail, subject, body);

            return response;
        }
    }
}