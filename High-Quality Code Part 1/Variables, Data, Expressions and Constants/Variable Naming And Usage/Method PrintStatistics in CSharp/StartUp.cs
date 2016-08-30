using System;

namespace Method_PrintStatistics_in_CSharp
{
    public class StartUp
    {
        public static void Main()
        {
        }

        public void PrintStatistics(double[] arr, int count)
        {
            double max = arr[0];

            for (int i = 0; i < count; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            Console.WriteLine(max);

            double min = arr[0];
            
            for (int i = 0; i < count; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            Console.WriteLine(min);

            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
            }

            double average = sum / count;

            Console.WriteLine(average);
        }
    }
}
