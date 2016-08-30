using System;

namespace RefactoredCSharpExam
{
    public static class BobbyAvokado
    {
        // Only 73/100 points :(
        public static void FindBestComb(uint bobbyHead, uint[] combs)
        {
            uint bestcomb = 0;
            uint comb = 0;

            for (int i = 0; i < combs.Length; i++)
            {
                comb = combs[i];
                if (bestcomb < comb &&
                    ((bobbyHead ^ comb) == (bobbyHead | comb)))
                {
                    string bestcombstr = Convert.ToString(bestcomb, 2);
                    string bobyheadstr = Convert.ToString(bobbyHead, 2);
                    if (bobyheadstr.Length < bestcombstr.Length)
                    {
                        continue;
                    }

                    bestcomb = comb;
                }
            }

            Console.WriteLine(bestcomb);
        }
    }
}
