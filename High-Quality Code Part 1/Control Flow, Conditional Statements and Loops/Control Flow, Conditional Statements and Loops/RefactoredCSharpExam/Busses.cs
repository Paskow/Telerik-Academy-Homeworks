using System;

namespace RefactoredCSharpExam
{
    public static class Busses
    {
        public static void CalculateGroups(int numberOfBusses, int[] bussesSpeed)
        {
            int groups = 0;
            int lastSpeed = 0;

            for (int i = 0; i < numberOfBusses; i++)
            {
                int speed = bussesSpeed[i];
                if (i == 0)
                {
                    lastSpeed = speed;
                }

                if (lastSpeed >= speed)
                {
                    groups++;
                    lastSpeed = speed;
                }
            }

            Console.WriteLine(groups);
        }
    }
}