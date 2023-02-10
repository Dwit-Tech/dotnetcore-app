using DwitTech.AccountService.Core.Interfaces;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Core.Services
{
    public class SecurityService : ISecurityService
    {
        
        public string HashString(string userPassword)
        {
            if (userPassword == null)
            {
                return null;
            }
            string collectedPassword = userPassword;
            byte[] hashPassword;
            byte[] asciibyte;

            asciibyte = ASCIIEncoding.ASCII.GetBytes(collectedPassword);
            hashPassword = new MD5CryptoServiceProvider().ComputeHash(asciibyte);
            return ConvertByteToString(hashPassword);
        }

         private string ConvertByteToString(byte[] hashPassword)
        {
            StringBuilder hashedStringOutput = new StringBuilder(hashPassword.Length);
            for (int i = 0; i < hashedStringOutput.Length; i++)
            {
                hashedStringOutput.Append(hashPassword[i].ToString("X2"));
            }
            return hashedStringOutput.ToString();
        }

    }

}
