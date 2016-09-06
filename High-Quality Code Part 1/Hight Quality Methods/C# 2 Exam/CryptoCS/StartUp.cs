using System;
using System.Numerics;

namespace CryptoCS
{
    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            BigInteger textResult = NumericSystems.AnyToDecimal(text, 26);
            string sign = Console.ReadLine();
            string substringValue = Console.ReadLine();
            BigInteger substringDecimalValue = NumericSystems.SevenToTen(substringValue);

            if (sign == "+")
            {
                BigInteger result = substringDecimalValue + textResult;
                Console.WriteLine(NumericSystems.DecimalToNine(result, 9));
            }
            else if (sign == "-")
            {
                BigInteger result = textResult - substringDecimalValue;
                Console.WriteLine(NumericSystems.DecimalToNine(result, 9));
            }
        }
    }
}