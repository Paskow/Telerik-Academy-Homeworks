using System;

namespace RefactoredForLoop
{
    public class StartUp
    {
        public static void Main()
        {
            var array = new int[100];
            var expectedValue = new Random().Next();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);

                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }
                }
            }
        }
    }
}
