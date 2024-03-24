using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖDEV_2
{
    class Program
    {
        // İteratif 
        static string DecimalToBinaryIterative(int number)
        {
            if (number == 0)
                return "0"; // O(1) 

            string result = ""; // O(1) 
            while (number > 0) // O(log n) 2'ye bölünerek logaritma
            {
                result = (number % 2) + result; // O(1) 
                number /= 2; // O(1) 
            }
            return result; // O(1) 
        }//T(n) = O(1) +O(1) +O(log n)+O(1) +O(1)  = O(log n)


        // Recursive
        static string DecimalToBinaryRecursive(int number)
        {
            if (number == 0)
            {
                return "0"; // O(1) 
            }
            else
            {
                return DecimalToBinaryRecursive(number / 2) + (number % 2); // O(log n)  değişkeni 2'ye bölünerek ,logaritma
            }
        }//T(n ) = O(1) +  O(log n) = O(log n) 


        static void Main(string[] args)
        {
            Console.WriteLine("Bir sayı girin:"); // O(1) 

            int number = Convert.ToInt32(Console.ReadLine()); // O(1) 

            string binaryIterative = DecimalToBinaryIterative(number); // O(log n) - İteratif fonksiyonunun karmaşıklığına bağlı
            Console.WriteLine($"İteratif: {binaryIterative}"); // O(1) 

            string binaryRecursive = DecimalToBinaryRecursive(number); // O(log n) recursive fonksiyonunun karmaşıklığına bağlı
            Console.WriteLine($"Recursive: {binaryRecursive}"); // O(1) 

            Console.ReadLine(); // O(1) 
        }

    }
}
