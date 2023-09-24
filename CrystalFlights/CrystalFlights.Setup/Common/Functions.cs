using System;
using System.Text;

namespace CrystalFlights.Setup
{
    public class Functions
    {
        public static string EncryptString(string str)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string GenerateRandomString(int length = 16)
        {
            string _numbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);
            Random random = new Random();

            for (var i = 0; i < length; i++)
            {
                builder.Append(_numbers[random.Next(0, _numbers.Length)]);
            }

            return builder.ToString();
        }

        public static long GenerateRandomNumber(int length = 6)
        {
            string _numbers = "0123456789";
            StringBuilder builder = new StringBuilder(length);
            Random random = new Random();
            
            for (var i = 0; i < length; i++)
            {
                builder.Append(_numbers[random.Next(0, _numbers.Length)]);
            }

            return long.Parse(builder.ToString());
        }
    }
}
