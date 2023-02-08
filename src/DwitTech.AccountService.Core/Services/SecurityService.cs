using DwitTech.AccountService.Core.Interfaces;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Core.Services
{
    public class SecurityService
    {
        private string ConvertByteToString(byte[] hashpassword)
        {
            StringBuilder hashedstringoutput = new StringBuilder(hashpassword.Length);
            for (int i = 0; i < hashedstringoutput.Length; i++)
            {
                hashedstringoutput.Append(hashpassword[i].ToString("X2"));
            }
            return hashedstringoutput.ToString();
        }

        public string GenerateHash(string userpassword)
        {
            if(userpassword == null)
            {
                return null;
            }

    }

}
