using DwitTech.AccountService.Core.Interfaces;
using DwitTech.AccountService.Core.Utilities;
using DwitTech.AccountService.Data.Entities;
using DwitTech.AccountService.Data.Context;
using System.Net.Mail;

namespace DwitTech.AccountService.Core.Services
{
    public class ValidationService : IValidationService
    {
        public static User user = new User();

        private readonly IActivationService _activationService;

        public ValidationService(IActivationService activationService)
        {
            _activationService = activationService;
        }

        public bool IsStatusPending(UserStatus status)
        {
            if (status == UserStatus.Pending)
            {
                return (IsUniqueActivationCode());
            }
            else
            {
                return false;
            }
        }


        public bool IsUniqueActivationCode()
        {
            var user = new User();
            {
                string activationCode = _activationService.GetActivationCode();

                if (!AccountDbContext.User.Any(x => x.activationCode == activationCode.ToString()))
                {
                    //generate activation url
                    string activationUrl = _activationService.GetActivationUrl();

                    //send activation Email
                    return _activationService.SendActivationEmail();
                }
            }
            return false;
        }

        public bool IsExpiredActivationCode(User user)
        {
            var activationCode = new RefreshActivationCode
            {
                activationCode = RandomUtil.GenerateUniqueCode(),
                Expires = DateTime.Now.AddMinutes(10),
                Created = DateTime.Now
            };

            if (!user.RefreshActivationCode.Equals(activationCode))
            {
                return false;
            }
            else if (user.ActivationCodeExpired == DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public bool SendWelcomeEmail(string From, string To, string Subject, string Body, string Cc, string Bcc, UserStatus status)
        {
                WelcomeEmail email = new WelcomeEmail();
                email.From = From;
                email.To = To;
                email.Subject = Subject;
                email.Body = Body;
                email.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(email);

            if(status == UserStatus.Active)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public string UpdateUserStatus(UserStatus status)
        {
     
        }
    }
}


