using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Core.Interfaces
{
    public interface IActivationService
    {
        bool SendActivationEmail(string from, string userEmail, string templatePath, string subject);
    }
}
