using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSetBits
{
    class Program
    {
        public static int countSetBitsFunc(int x)
        {
            int count;
            if (x < 0) return 0;

            count = x % 2 == 0 ? 0 : 1 + countSetBitsFunc(x / 2);
            return count;
        }

        public static int countSetBits(int n)
        {
            int bitCount = 0;

            for (int i = 0; i < n; i++)
            {
                bitCount += countSetBitsFunc(i);
            }
            return bitCount;
        }
        static void Main(string[] args)
        {
            int n = 7;
            int result = countSetBits(n);
            Console.WriteLine("Set bits = {0}", result);
        }
    }
}
