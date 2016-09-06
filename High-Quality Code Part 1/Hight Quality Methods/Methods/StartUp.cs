using System;

namespace Methods
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine(MathUtils.CalculateTriangleArea(3, 4, 5));
            Console.WriteLine(MathUtils.DigitToString(5));
            Console.WriteLine(MathUtils.FindMax(5, -1, 3, 2, 14, 2, 3));

            MathUtils.PrintAsNumber(1.3, "f");
            MathUtils.PrintAsNumber(0.75, "%");
            MathUtils.PrintAsNumber(2.30, "r");

            bool horizontal = MathUtils.IsHorizontal(-1, 2.5);
            bool vertical = MathUtils.IsVerical(3, 3);

            Console.WriteLine(MathUtils.CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName, 
                stella.FirstName, 
                peter.IsOlderThan(stella));
        }
    }
}
