using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        public static string GetHash(string key)
        {
            MD5 md5 = MD5.Create();
            byte[] hashData = md5.ComputeHash(Encoding.UTF8.GetBytes(key));

            StringBuilder sb = new StringBuilder();
            foreach(var data in hashData)
            {
                sb.Append(data.ToString("x2"));
            }
            return sb.ToString();
        }

        public static void Main(string[] args)
        {
            string key = "bgvyzdsv";
            int answer = 0;
            while (true)
            {
                string keyHash = GetHash(key + answer);
                if (Regex.IsMatch(keyHash, @"^00000\w+")){

                    break;
                }
                else
                {
                    answer++;
                }
            }
            Console.WriteLine("Secret key is:" +key+answer);
            Console.WriteLine("Secret key hash:" + GetHash(key + answer));
        }
    }
}
