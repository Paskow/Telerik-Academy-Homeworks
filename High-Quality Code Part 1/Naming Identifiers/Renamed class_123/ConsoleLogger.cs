using System;

namespace RenamedCodes
{
    class ConsoleLogger
    {
        public void LogBool(bool value)
        {
            string valueAsString = value.ToString();
            Console.WriteLine(valueAsString);
        }
    }
}
