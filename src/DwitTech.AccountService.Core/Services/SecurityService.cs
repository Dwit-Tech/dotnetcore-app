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
        
        public string HashString(string inputString)
        {
            if (inputString == null)
            {
                return null;
            }
            string collectedPassword = inputString;
            byte[] inputStringHash;
            byte[] asciiByte;

            asciiByte = ASCIIEncoding.ASCII.GetBytes(inputString);
            inputStringHash = new MD5CryptoServiceProvider().ComputeHash(asciiByte);
            return ConvertByteToString(inputStringHash);
        }

         private string ConvertByteToString(byte[] inputString)
        {
            StringBuilder hashedStringOutput = new StringBuilder(inputString.Length);
            for (int i = 0; i < hashedStringOutput.Length; i++)
            {
                hashedStringOutput.Append(inputString[i].ToString("X2"));
            }
            return hashedStringOutput.ToString();
        }

    }

}
