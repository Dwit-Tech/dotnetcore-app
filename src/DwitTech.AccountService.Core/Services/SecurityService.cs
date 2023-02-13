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
        
        public string HashString(string InputString)
        {
            if (InputString == null)
            {
                return null;
            }
            /*string collectedPassword = inputString;*/
            byte[] InputStringHash;
            byte[] asciibyte;

            asciibyte = ASCIIEncoding.ASCII.GetBytes(InputString);
            InputStringHash = new MD5CryptoServiceProvider().ComputeHash(asciibyte);
            return ConvertByteToString(InputStringHash);
        }

         private string ConvertByteToString(byte[] InputString)
        {
            StringBuilder hashedStringOutput = new StringBuilder(InputString.Length);
            for (int i = 0; i < hashedStringOutput.Length; i++)
            {
                hashedStringOutput.Append(InputString[i].ToString("X2"));
            }
            return hashedStringOutput.ToString();
        }

    }

}
