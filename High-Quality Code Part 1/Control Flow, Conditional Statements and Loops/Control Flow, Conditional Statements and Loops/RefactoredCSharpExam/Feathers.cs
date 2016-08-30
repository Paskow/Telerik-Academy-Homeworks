using System;

namespace RefactoredCSharpExam
{
    public static class Feathers
    {
        public static void ClaculateFeathers(double numberOfBirds, double numberOfBirdFeathers)
        {
            // double numberOfBirds = double.Parse(Console.ReadLine());  reading from console for exam
            // double numberOfBirdFeathers = double.Parse(Console.ReadLine());
            if (numberOfBirds != 0 && numberOfBirdFeathers != 0)
            {
                double average = numberOfBirdFeathers / numberOfBirds;
                if (numberOfBirds % 2 == 0 && numberOfBirds != 1)
                {
                    Console.WriteLine("{0:F4}", average * 123123123123);
                }
                else
                {
                    Console.WriteLine("{0:F4}", average / 317);
                }
            }
            else
            {
                Console.WriteLine("{0:F4}", 0);
            }
        }
    }
}
