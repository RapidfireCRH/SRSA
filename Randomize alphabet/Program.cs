using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Randomize_alphabet
{
    class Program
    {

        static DateTime Timer = DateTime.Now;
        static DateTime Start = DateTime.Now;
        static void Main(string[] args)
        {
            int numoftimes = 1000000;
            string[] collection = new string[numoftimes];
            for (int i = 0; i != numoftimes; i++)
            {
                collection[i] = getrandom();
                display(collection[i], i, numoftimes);
            }
            display(collection[collection.Length-1], numoftimes, numoftimes, true);
            Console.Read();
        }
        static string  getrandom()
        {
            string randomalpha = "";
            DateTime Timer = DateTime.Now;
            DateTime Start = DateTime.Now;
            string fivetwelvecache = "";
            while (randomalpha.Length != 62)
            {
                if (fivetwelvecache.Length == 0)
                    fivetwelvecache = loadnext512();
                if (!randomalpha.Contains(fivetwelvecache[0]))
                    randomalpha += fivetwelvecache[0];
                fivetwelvecache = fivetwelvecache.Substring(1, fivetwelvecache.Length - 1);
            }
            return randomalpha;
        }
        static string loadnext512()
        {
            //string ret = "";
            //while (ret.Length < 512)
            //{
            //    string temp = Path.GetRandomFileName();
            //    ret = ret + temp;
            //    ret = ret.Replace(".", "");
            //}
            //return ret.Substring(0, 512);
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[512];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);

        }
        static void display(string current, int num, int maxnum, bool force = false)
        {
            if (DateTime.Now.Second != Timer.Second || force)
            {
                Console.Clear();
                Console.WriteLine(current);
                Console.WriteLine(num + "/"+ maxnum);
                Console.WriteLine(Math.Round(Timer.Subtract(Start).TotalSeconds, 0) + " Seconds Elapsed");
                Timer = DateTime.Now;
            }
        }
    }
}
