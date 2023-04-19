using System;
using System.Collections.Generic;

namespace IndexOfCapitals;

class Program {
    static int[] IndexOfCapitals(string str) {
        List<int> indices = new List<int>();
        for (int i = 0; i < str.Length; i++) {
            if (Char.IsLetter(str[i]) && Char.IsUpper(str[i])) {
                indices.Add(i);
            }
        }
        return indices.ToArray();
    }
    
    static void Main(string[] args) {
        Console.WriteLine(String.Join(", ", IndexOfCapitals("eDaBiT"))); 
        Console.WriteLine(String.Join(", ", IndexOfCapitals("eQuINoX"))); 
        Console.WriteLine(String.Join(", ", IndexOfCapitals("determine")));
        Console.WriteLine(String.Join(", ", IndexOfCapitals("STRIKE")));
        Console.WriteLine(String.Join(", ", IndexOfCapitals("sUn"))); 
    }
}
