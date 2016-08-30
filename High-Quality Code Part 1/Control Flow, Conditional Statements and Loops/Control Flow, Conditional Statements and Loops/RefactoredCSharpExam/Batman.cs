using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredCSharpExam
{
    public class Batman
    {
        public void PrintBatman(int parameter, char ch)
        {
            int width = 3 * parameter;
            int height = (parameter / 3) + (parameter - 1);
            int update = 0;
            int update2 = 0; // I dont even remember for what is this :D 

            for (int row = 1; row <= height; row++)
            {
                for (int col = 1; col <= width; col++)
                {
                    if ((row <= parameter / 2 && col <= parameter && col > update) ||
                        (row <= parameter / 2 && col >= width - parameter + 1 && col <= width - update) ||
                        (row == parameter / 2 && (col == parameter + (parameter / 2) || col == parameter + (parameter / 2) + 2)) ||
                        (row > parameter / 2 && row <= height - (parameter / 2) && col > (parameter / 2) && col <= width - (parameter / 2)) ||
                        (row > (parameter / 2) + (parameter / 3) && col > parameter + 1 + update2 && col <= width - 1 - parameter - update2))
                    {
                        Console.Write(ch);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                if (row > (parameter / 2) + (parameter / 3))
                {
                    update2++;
                }

                update++;         
                Console.WriteLine();
            }
        }
    }
}
