using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeziciAlgoritması
{
    class Program
    {
        static int Iterative(int[,] graph, int baslangic)
        {
            int n = graph.GetLength(0);//grafın bboyutunu alır o(1)
            int[] ziyaret = new int[n - 1];// ziyaret edilen şehirşer için liste oluşturur O(n)
            for (int i = 0; i < n - 1; i++)//başlangıc noktası hariç diğer şehirleri atar O(n)
                ziyaret[i] = i + 1;

            int min_path = int.MaxValue;//min değer O(1)
            do
            {
                int current_pathweight = 0;//yol agırlıgını tutar sonraki için sıfırlar O(1)

                int k = baslangic;//başlangıç noktasını k değerine atar O(1)
                for (int i = 0; i < n - 1; i++)//tüm şehirleri gezene kadar döner O(n)
                {
                    current_pathweight += graph[k, ziyaret[i]];//mesafeleri toplar
                    k = ziyaret[i];//bir sonraki şehir O(1)
                }
                current_pathweight += graph[k, baslangic];//sondan başlangıc noktasına geri döer O(1)

                min_path = Math.Min(min_path, current_pathweight);//mesafeleri karşılaştırır O(N!)

            } while (NextPermutation(ziyaret));

            return min_path;//mesafesi en kısa olanı döndürür
        }// O(1) + O(N) + O(N!) + O(1) = O(N!)

        // Gezgin satıcı problemi için recursive çözüm
        static int Recursive(int[,] graph, int baslangic, int[] ziyaret, int count)
        {
            int n = graph.GetLength(0);//grafın boyutunu alır  O(1)
            if (count == n - 1)//tüm şehirler gezilmişşse başlangıca döner O(1)
                return graph[baslangic, 0]; //O(1)

            int min_cost = int.MaxValue;//min değeri tutar  O(1)
            for (int i = 0; i < n; i++)// O(n)
            {
                if (ziyaret[i] == 0)//tüm şehirleri gezmek için O(1)
                {
                    ziyaret[i] = 1;//şehri ziyaret edildi diye işaretler O(1)
                    int current_cost = graph[baslangic, i] + Recursive(graph, i, ziyaret, count + 1);//  T(n-1) -> Recursive çağrı,
                    //bir sonrki şehre gitmek maliyet hesabı yapar recursive olarak birbirini çagırır
                    min_cost = Math.Min(min_cost, current_cost);//mesafeler arasında karşılastırma yapar
                    ziyaret[i] = 0;//başlangıç noktasına geri dönmek için başlangıcı ziyaret edilmedi diye işaretler
                }
            }
            return min_cost;//en kısa mesafeyi dödürür
        }//şehirlerin permütasyonlarını gezdiği için, karmaşıklığı O(N!) olacak

        // Bir sonraki permütasyonu bulmak için yardımcı fonksiyon
        static bool NextPermutation(int[] array)
        {
            int i = array.Length - 2;//sondan bir önceki elemandan başlar
            while (i >= 0 && array[i] >= array[i + 1])
                i--;
            if (i < 0)//azalan sayı yoksa diziyi ters çevirir
                return false;

            int j = array.Length - 1;//azalan sıra
            while (array[j] <= array[i])//azalandan daha büyük bulmak için sondan başlar
                j--;

            int temp = array[i];//buldugu eleman ile swap işlemi yapar
            array[i] = array[j];
            array[j] = temp;

            Array.Reverse(array, i + 1, array.Length - i - 1);//tüm elemanları ters ceivirir

            return true;
        }

        public static void Main()
        {
            int[,] graph = { { 0, 10, 15, 20 },//şehirler arası mesafeyi kontrol eder   O(1)
                             { 10, 0, 35, 25 },// O(1)
                             { 15, 35, 0, 30 },// O(1)
                             { 20, 25, 30, 0 } };// O(1)
            int baslangic = 0;//başlangız noktası  O(1)
            int n = graph.GetLength(0);//grafın boyutunu alır (şehir sayısı)  O(1)
            int[] ziyaret = new int[n];//ziyaret edilen şehirler için dizi  O(n)
            ziyaret[baslangic] = 1;//başlangıcı ziyaret edildi diye işaretler O(1)

            Console.WriteLine("Minimum yol maliyeti (iterative): " + Iterative(graph, baslangic));// O(n!)
            Console.WriteLine("Minimum yol maliyeti (recursive): " + Recursive(graph, baslangic, ziyaret, 0));// O(n!)
            Console.ReadLine();// O(1)

        }
    }
}
