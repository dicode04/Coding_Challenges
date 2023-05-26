using System;

class Program
{
    static int GetSecondMaximum(int a, int b, int c)
    {
        if ((a >= b && a <= c) || (a <= b && a >= c))
            return a;
        else if ((b >= a && b <= c) || (b <= a && b >= c))
            return b;
        else
            return c;
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < N; i++)
        {
            string[]? input = Console.ReadLine()?.Split(' ');
            if (input != null && input.Length == 3)
            {
                int num1 = int.Parse(input[0]);
                int num2 = int.Parse(input[1]);
                int num3 = int.Parse(input[2]);

                int secondMax = GetSecondMaximum(num1, num2, num3);
                Console.WriteLine(secondMax);
            }
        }
    }
}
