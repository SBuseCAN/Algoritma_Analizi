using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖDEV_1
{
    class Program
    {
        public class IterativeMaxFinder
        {
            public int FindMax(int[] arr)
            {
                if (arr == null || arr.Length == 0)// O(1)
                    throw new ArgumentException("Dizi boş olamaz.");

                int max = arr[0];//O(1) eleman ataması yapar
                for (int i = 1; i < arr.Length; i++)//o (n) diziyi buyutu kadar dolaşır 
                {
                    if (arr[i] > max)//O(1)
                        max = arr[i];//o(1)
                }
                return max;//O(1) deger dondurme
            }
        }// kullanıcıdan dizi boyutununa göre eleman alma O(n)
        // T(n)=O(1)+ O(1)+ O(n)+ O(1) +O(1) = O(n)
        public class RecursiveMaxFinder
        {
            public int FindMax(int[] arr)
            {
                if (arr == null || arr.Length == 0)// O(1)
                    throw new ArgumentException("Dizi boş olamaz.");

                return FindMaxRecursive(arr, arr.Length);// O(1)fonksiyon cagırma
            }

            private int FindMaxRecursive(int[] arr, int n)
            {
                if (n == 1)// O(1)
                    return arr[0];
                return Math.Max(arr[n - 1], FindMaxRecursive(arr, n - 1));
            }//O(n) kadar döner
        }// T(N) = O(1)+ O(1)+ O(1)+ O(n) = O(n)

        static void Main(string[] args)
        {
            Console.WriteLine("Dizinin boyutunu girin:");
            int size = Convert.ToInt32(Console.ReadLine()); // O(1) dizi boyutunu al

            int[] arr = new int[size]; // O(1) Dizi oluşturur
            Console.WriteLine($"Lütfen {size} tane sayı girin:");
            for (int i = 0; i < size; i++) // O(n) elemanlarını al
            {
                arr[i] = Convert.ToInt32(Console.ReadLine()); // O(1)girdi alır ve atama işlemi yapar 
            }

            IterativeMaxFinder iterativeMaxFinder = new IterativeMaxFinder(); // O(1) nesne oluştur
            int maxIterative = iterativeMaxFinder.FindMax(arr); // O(n) foksiyon çağırma
            Console.WriteLine("Iteratif Yaklaşım ile En Büyük Sayı: " + maxIterative); // O(1) ekrana yaz

            RecursiveMaxFinder recursiveMaxFinder = new RecursiveMaxFinder(); // O(1) nesne oluştur
            int maxRecursive = recursiveMaxFinder.FindMax(arr); // O(n) fonkisyon çagırma
            Console.WriteLine("Rekürsif Yaklaşım ile En Büyük Sayı: " + maxRecursive); // O(1)ekrana yaz

            Console.ReadLine();

        }
    }
}
