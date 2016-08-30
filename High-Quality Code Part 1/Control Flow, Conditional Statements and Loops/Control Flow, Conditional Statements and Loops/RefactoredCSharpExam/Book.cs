using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredCSharpExam
{
    public class Book
    {
        public void CalculatePagesDigits(int pages)
        {
            int totalDigits = 0;

            for (int i = 1; i <= pages; i++)
            {
                if (i < 10)
                {
                    totalDigits++;
                }
                else if (i < 100)
                {
                    totalDigits += 2;
                }
                else if (i < 1000)
                {
                    totalDigits += 3;
                }
                else if (i < 10000)
                {
                    totalDigits += 4;
                }
                else if (i < 100000)
                {
                    totalDigits += 5;
                }
                else if (i < 1000000)
                {
                    totalDigits += 6;
                }
            }

            Console.WriteLine(totalDigits);
        }
    }
}
