using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Core.Utilities
{
    public static class RandomUtil 

    {
        internal static readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        public static string GenerateUniqueCode(int numberOfCharacters=20, bool useNumbers = true, bool useAlphabets = true, bool useSymbols = false)
        {
            byte[] data = new byte[4 * numberOfCharacters];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(numberOfCharacters);

            for (int i = 0; i < numberOfCharacters; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();

        }
    }
}
