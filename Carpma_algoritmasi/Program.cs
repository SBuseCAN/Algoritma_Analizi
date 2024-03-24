using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpma_algoritmasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // İlk sayıyı ve ikinci sayıyı tanımla
            int ilkSayi = 2135;
            int ikinciSayi = 4014;

            // İki sayının çarpımını hesapla
            int carpimSonucu = Carpma(ilkSayi, ikinciSayi);

            // Sonucu ekrana yazdır
            Console.WriteLine($"Çarpma Sonucu: {carpimSonucu}");
        }

        // İki sayının çarpımını gerçekleştiren fonksiyon
        static int Carpma(int a, int b)
        {
            // Sonucu saklamak için bir değişken tanımla
            int sonuc = 0;

            // İkinci sayı sıfır olana kadar döngüyü devam ettir
            while (b != 0)
            {
                // İkinci sayının son bitine bak ve 1 ise birinci sayıyı sonuca ekle
                if ((b & 1) != 0)
                {
                    sonuc += a;
                }

                // Birinci sayıyı sola kaydır
                a <<= 1;

                // İkinci sayıyı sağa kaydır
                b >>= 1;
            }
            return sonuc;
            Console.ReadLine();
        }
    }
}
