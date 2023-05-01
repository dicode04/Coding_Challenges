namespace Collatz;
public class Program{
    //collatz function to return a positive arbitrary integer if:
    // n is even -> n/2
    // n is odd -> 3n+1
    static int Collatz(int n) {
        int steps = 0;
        while (n != 1) {           //while loop to iterate until n is equal to 1
            if (n % 2 == 0) {
                n /= 2;
            } else {
                n = 3 * n + 1; 
            }
            steps++;
        }
        return steps;
    }
    static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());
        int steps = Collatz(n);
        Console.WriteLine(steps);
    }
}