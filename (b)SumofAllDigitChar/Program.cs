using System;

class Program
{
    static int SumOfDigits(string input)
    {
        int sum = 0;

        foreach (char c in input)
        {
            if (Char.IsDigit(c))
            {
                int digit = c - '0';
                sum += digit;
            }
        }

        return sum;
    }

    static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < T; i++)
        {
            string input = Console.ReadLine()!;
            int sum = SumOfDigits(input);
            Console.WriteLine(sum);
        }
    }
}
