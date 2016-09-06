using System;
using System.Numerics;

namespace CryptoCS
{
    public static class NumericSystems
    {
        public static BigInteger AnyToDecimal(string word, int system)
        {
            BigInteger result = 0;
            int wordLength = word.Length - 1;
            BigInteger pow = 26;
            for (int i = wordLength; i >= 0; i--)
            {
                result += (word[i] - 97) * pow;
                pow *= 26;
            }

            return result;
        }
 
        public static BigInteger SevenToTen(string hexValue)
        {
            BigInteger result = 0;
            string sevenValue = hexValue.TrimStart('-');
            BigInteger pow = 7;

            for (int i = sevenValue.Length - 1; i >= 0; i--)
            {
                result += (sevenValue[i] - 48) * pow;
                pow *= 7;
            }

            if (hexValue[0] == '-')
            {
                return -result;
            }

            return result;           
        }

        public static string DecimalToNine(BigInteger number, int system)
        {
            string word = "";
            char[] alphabet = "012345678".ToCharArray();
            long charIndex = 0;
            bool isPossitive = number < 0;

            if (number < 0)
            {
                number *= -1;
            }

            while (number >= system)
            {
                charIndex = (int)(number % system);

                word = Convert.ToString(charIndex) + word;

                number /= system;
            }

            charIndex = (int)(number % system);
            word = Convert.ToString(charIndex) + word;

            if (isPossitive)
            {
                return "-" + word;
            }

            return word;
        }
    }
}
