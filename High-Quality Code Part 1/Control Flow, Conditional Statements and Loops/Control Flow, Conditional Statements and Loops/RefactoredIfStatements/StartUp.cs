using System;

namespace RefactoredIfStatements
{
    public class StartUp
    {
        public static void Main()
        {
            Potato potato = new Potato();

            if (potato != null)
            {
                if (!potato.HasNotBeenPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
            }

            var x = 5;
            var y = 5;
            const int MinX = 5;
            const int MaxX = 5;
            const int MinY = 5;
            const int MaxY = 5;
            bool shouldNotVisitCell = true;

            if ((MinX <= x && x <= MaxX) && 
                (MinY <= y && y >= MaxY) && 
                !shouldNotVisitCell)
            {
                VisitCell();
            }
        }

        private static void VisitCell()
        {
        }

        private static void Cook(Potato potato)
        {
        }
    }
}
