using System;
using System.Linq;

namespace Kitty
{
    public class StartUp
    {
        public static void Main()
        {
            char[] possitions = Console.ReadLine().ToCharArray();
            long[] moves = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            bool kittyCatched = false;
            int movesMaded = 0;
            char soul = '@';
            char food = '*';
            char deadlock = 'x';
            int deadlocks = 0;
            int soulsCollected = 0;
            int foodCollected = 0;
            long index = 0;

            for (int i = 0; i <= moves.Length; i++)
            {
                if (i != 0)
                {
                    if (index + moves[i - 1] < 0)
                    {
                        long count = moves[i - 1];
                        while (count != 0)
                        {
                            index--;
                            if (index < 0)
                            {
                                index = possitions.Length - 1;
                            }

                            count++;
                        }
                    }
                    else if (index + moves[i - 1] > possitions.Length - 1)
                    {
                        long count = moves[i - 1];
                        while (count != 0)
                        {
                            index++;
                            if (index > possitions.Length - 1)
                            {
                                index = 0;
                            }

                            count--;
                        }
                    }
                    else
                    {
                        index = index + moves[i - 1];
                    }
                }

                if (possitions[index] == soul)
                {
                    soulsCollected++;
                    possitions[index] = ' ';
                }
                else if (possitions[index] == food)
                {
                    foodCollected++;
                    possitions[index] = ' ';
                }
                else if (possitions[index] == deadlock)
                {
                    if (index % 2 == 0)
                    {
                        if (soulsCollected > 0)
                        {
                            possitions[index] = soul;
                            soulsCollected--;
                            deadlocks++;
                        }
                        else
                        {
                            kittyCatched = true;
                            Console.WriteLine("You are deadlocked, you greedy kitty!");
                            Console.WriteLine("Jumps before deadlock: " + movesMaded);
                            break;
                        }
                    }
                    else
                    {
                        if (foodCollected > 0)
                        {
                            possitions[index] = food;
                            foodCollected--;
                            deadlocks++;
                        }
                        else
                        {
                            kittyCatched = true;
                            Console.WriteLine("You are deadlocked, you greedy kitty!");
                            Console.WriteLine("Jumps before deadlock: " + movesMaded);
                            break;
                        }
                    }
                }

                movesMaded++;
            }

            if (kittyCatched == false)
            {
                Console.WriteLine("Coder souls collected: " + soulsCollected);
                Console.WriteLine("Food collected: " + foodCollected);
                Console.WriteLine("Deadlocks: " + deadlocks);
            }
        }
    }
}
