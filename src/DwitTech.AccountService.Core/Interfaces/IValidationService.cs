using DwitTech.AccountService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Core.Interfaces
{
    public interface IValidationService
    {
        bool IsUniqueActivationCode();
        bool IsStatusPending(UserStatus status);
        bool IsExpiredActivationCode(User user);
        bool SendWelcomeEmail(string From, string To, string Subject, string Body, string Cc, string Bcc, UserStatus status);
        string UpdateUserStatus(UserStatus status);
        
        
        
    }
}
