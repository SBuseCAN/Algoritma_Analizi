using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ödev_5
{
    class Program
    {
        // İteratif Yaklaşım
        static int IteratifFaktoriyel(int sayi)
        {
            int sonuc = 1;//o(1)
            for (int i = 2; i <= sayi; i++)//o(n)
            {
                sonuc *= i;//o(1)
            }
            return sonuc;//o(1)
        }//t(n) = O(1) + n * O(1) + O(1) = O(n)

        // Özyinelemeli (Recursive) Yaklaşım
        static int RecursiveFaktoriyel(int sayi)
        {
            if (sayi == 0 || sayi == 1)//o(1)
                return 1;
            else
                return sayi * RecursiveFaktoriyel(sayi - 1);// t(n-1) 
        }//t(n) = O(1) + t(n-1) = O(n)

        static void Main(string[] args)
        {
            Console.Write("Faktoriyelini hesaplamak istediğiniz sayıyı girin: ");//O(1)
            int sayi = Convert.ToInt32(Console.ReadLine());

            int iteratifSonuc = IteratifFaktoriyel(sayi);//O(n)
            Console.WriteLine("\nİteratif: " + iteratifSonuc);
 
            int recursiveSonuc = RecursiveFaktoriyel(sayi);//o(n)
            Console.WriteLine("Recursive: " + recursiveSonuc);
            Console.ReadLine();
        }
    }
}
