using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Graph
    {
        private int V; // Şehir sayısı
        private int[,] distanceMatrix; // Şehirler arasındaki mesafeleri tutacak matris

        // Graph sınıfının yapıcı metodu
        public Graph(int v)
        {
            V = v; // Şehir sayısını ayarla
            distanceMatrix = new int[V, V]; // Şehirler arasındaki mesafe matrisini oluştur
        }

        // Rastgele mesafe matrisi oluştur
        public void RandomDistanceMatrix()
        {
            Random rnd = new Random(); // Rastgele sayı üretmek için nesne oluştur
            for (int i = 0; i < V; i++)
            {
                for (int j = i + 1; j < V; j++)
                {
                    int distance = rnd.Next(50, 101); // 50-100 arası rastgele bir mesafe
                    distanceMatrix[i, j] = distance;
                    distanceMatrix[j, i] = distance; // Matris simetrik olduğundan diğer yarıyı da doldur
                }
            }
        }

        // Mesafe matrisini döndür
        public int[,] GetDistanceMatrix()
        {
            return distanceMatrix;
        }

        // Dijkstra algoritması
        public int Dijkstra(int src, int[,] matrix)
        {
            // src: başlangıç düğümü
            // matrix: şehirler arasındaki mesafelerin matrisi

            // distances: başlangıç düğümünden diğer düğümlere olan en kısa mesafelerin dizisi
            int[] distances = new int[V];
            // visited: düğümlerin ziyaret edilip edilmediğini tutan dizi
            bool[] visited = new bool[V];

            // Her düğüme sonsuz mesafe ataması yapılır
            for (int i = 0; i < V; i++)
            {
                distances[i] = int.MaxValue;
            }
            // Başlangıç düğümüne olan mesafe sıfır olarak ayarlanır
            distances[src] = 0;

            // Diğer düğümlere olan en kısa mesafeyi bulmak için V-1 kez döngü çalışır
            for (int count = 0; count < V - 1; count++)
            {
                // Henüz işlenmemiş olan düğümler arasından en kısa mesafeye sahip olanı bulunur
                int u = MinDistance(distances, visited);
                // Bu düğüm işlenmiş olarak işaretlenir
                visited[u] = true;

                // Seçilen düğümden henüz işlenmemiş olan diğer düğümlere olan mesafeler kontrol edilir
                for (int v = 0; v < V; v++)
                {
                    // İki düğüm arasında bir bağlantı varsa ve yeni yol, önceki mesafeden daha kısa ise,
                    // mesafe güncellenir
                    if (!visited[v] && matrix[u, v] != 0 && distances[u] != int.MaxValue && distances[u] + matrix[u, v] < distances[v])
                    {
                        distances[v] = distances[u] + matrix[u, v];
                    }
                }
            }

            // En kısa mesafeler yazdırılır
            Console.WriteLine("Dijkstra algoritması ile hesaplanan en kısa mesafeler:");
            for (int i = 0; i < V; ++i)
            {
                Console.WriteLine($"Şehir {src} - Şehir {i}: {distances[i]}");
            }
            Console.WriteLine();

            // Toplam mesafeyi döndürür
            return distances.Sum();
        }

        // Dijkstra algoritmasında kullanılan yardımcı metot
        private int MinDistance(int[] distances, bool[] visited)
        {
            // Başlangıçta minimum mesafe sonsuz olarak atanır
            int min = int.MaxValue, minIndex = -1;

            // Tüm düğümler gezilir ve henüz işlenmemiş olan ve en kısa mesafeye sahip olan bulunur
            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && distances[v] <= min)
                {
                    min = distances[v];
                    minIndex = v;
                }
            }

            // En kısa mesafeye sahip düğümün indisini döndürür
            return minIndex;
        }
        /*Dijkstra N-1 kez döner MinDistance fonksiyonu çağrılır, 
        bu fonksiyon da N kez döner İç içe döngüler olduğu için 
        toplam işlem sayısı N * (N - 1) olur, karmaşıklığı O(N^2)'dir.
        t(n) = O (n^2) olur */


        // Prim algoritması

        public int Prim(int[,] matrix)
        {
            // matrix: şehirler arasındaki mesafelerin matrisi

            // parent: minimum ağaçtaki her düğümün bir önceki düğümünü tutan dizi
            int[] parent = new int[V];
            // key: her düğüme olan minimum ağırlığı (mesafeyi) tutan dizi
            int[] key = new int[V];
            // mstSet: minimum ağaçta bulunan düğümleri işaretleyen dizi
            bool[] mstSet = new bool[V];

            // Her düğüme sonsuz mesafe atanır ve henüz işlenmemiş olarak işaretlenir
            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            // Başlangıç düğümü için mesafe sıfır olarak ayarlanır ve ebeveyni -1 olarak atanır
            key[0] = 0;
            parent[0] = -1;

            // Minimum ağacı oluşturmak için V-1 kez döngü çalışır
            for (int count = 0; count < V - 1; count++)
            {
                // Henüz işlenmemiş olan düğümler arasından minimum ağırlığa sahip olanı bulunur
                int u = MinKey(key, mstSet);
                // Bu düğüm işlenmiş olarak işaretlenir
                mstSet[u] = true;

                // Seçilen düğümün komşuları arasında henüz işlenmemiş olan ve daha küçük bir ağırlığa sahip olanlar kontrol edilir
                for (int v = 0; v < V; v++)
                {
                    // İki düğüm arasında bir bağlantı varsa ve yeni yol, önceki mesafeden daha kısa ise,
                    // mesafe güncellenir ve ebeveyn düğümü güncellenir
                    if (matrix[u, v] != 0 && !mstSet[v] && matrix[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = matrix[u, v];
                    }
                }
            }

            // Minimum ağacı yazdır
            Console.WriteLine("Prim algoritması ile hesaplanan minimum ağaç:");
            Console.WriteLine("Kenar \t Uzaklık");
            for (int i = 1; i < V; i++)
            {
                Console.WriteLine($"Şehir {parent[i]} - Şehir {i} \t {matrix[i, parent[i]]}");
            }
            Console.WriteLine();

            // Toplam mesafeyi döndürür
            return key.Sum();
        }

        // Prim algoritmasında kullanılan yardımcı metot
        private int MinKey(int[] key, bool[] mstSet)
        {
            // Başlangıçta minimum mesafe sonsuz olarak atanır
            int min = int.MaxValue, minIndex = -1;

            // Tüm düğümler gezilir ve henüz işlenmemiş olan ve en küçük ağırlığa sahip olan bulunur
            for (int v = 0; v < V; v++)
            {
                if (!mstSet[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            // En küçük ağırlığa sahip düğümün indisini döndürür
            return minIndex;
        }
        /*Prim  N-1 kez döner Her döngüde MinKey çağrılır,
        MinKey de N kez döner
        İç içe döngüler olduğu  N * (N - 1) olur
        Dolayısıyla, Prim algoritmasının karmaşıklığı O(N^2)'dir.

         */

        // Kruskal algoritması
        public int Kruskal(int[,] matrix)
        {
            // matrix: şehirler arasındaki mesafelerin matrisi

            // Tüm olası kenarları depolamak için bir liste oluşturulur
            List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();

            // Tüm düğümler arasındaki kenarları tespit etmek için çift döngü
            for (int i = 0; i < V; i++)
            {
                for (int j = i + 1; j < V; j++)
                {
                    // Şehirler arasında bir bağlantı varsa, kenar listesine eklenir
                    if (matrix[i, j] != 0)
                    {
                        edges.Add(Tuple.Create(i, j, matrix[i, j]));
                    }
                }
            }

            // Kenarları uzunluklarına göre sırala
            edges = edges.OrderBy(edge => edge.Item3).ToList();

            // Her düğümün kökünü tutacak olan bir dizi oluştur
            int[] parent = new int[V];
            for (int i = 0; i < V; i++)
            {
                parent[i] = i;
            }

            // Minimum ağacı bulmak için gerekli değişkenler oluşturulur
            List<Tuple<int, int, int>> minimumSpanningTree = new List<Tuple<int, int, int>>();
            int totalDistance = 0;

            // Kenarları kontrol et
            foreach (var edge in edges)
            {
                // Kenarın iki ucunun kökleri bulunur
                int x = Find(parent, edge.Item1);
                int y = Find(parent, edge.Item2);

                // Eğer kenarın iki ucunun kökleri farklıysa, bu kenar minimum ağaca eklenebilir
                if (x != y)
                {
                    minimumSpanningTree.Add(edge);
                    totalDistance += edge.Item3;
                    Union(parent, x, y);
                }
            }

            // Minimum ağacı yazdır
            Console.WriteLine("Kruskal algoritması ile hesaplanan minimum ağaç:");
            Console.WriteLine("Kenar \t Uzaklık");
            foreach (var edge in minimumSpanningTree)
            {
                Console.WriteLine($"Şehir {edge.Item1} - Şehir {edge.Item2} \t {edge.Item3}");
            }
            Console.WriteLine();

            // Toplam mesafeyi döndürür
            return totalDistance;
        }

        // Kruskal algoritmasında kullanılan yardımcı metotlar

        // Bir düğümün kökünü bulur
        private int Find(int[] parent, int i)
        {
            if (parent[i] == i)
            {
                return i;
            }
            // Düğümün kökünü rekürsif olarak bulur
            return Find(parent, parent[i]);
        }

        // İki kökü birleştirir
        private void Union(int[] parent, int x, int y)
        {
            // İlk kök, ikinci kökün alt kümesine bağlanır
            int xset = Find(parent, x);
            int yset = Find(parent, y);
            parent[xset] = yset;
        }
    }
       /*Kruskal algoritması, sıralama işlemi dışında tüm işlemleri tek seferde yapar.
         Tüm kenarları sıralamak O(e log e)( e = kenar) karmaşıklığına sahiptir. 
      Kruskal karmaşıklığı  O(e log e) olur
      n: düğüm sayısı  Kruskal t(n) = O(e log e) */

    class Program
    {
        static void Main()
        {
            Graph g = new Graph(6); // 6 şehir olacak şekilde bir graf oluştur

            g.RandomDistanceMatrix(); // Şehirler arası rastgele mesafeleri oluştur
            int[,] distanceMatrix = g.GetDistanceMatrix(); // Aynı mesafe matrisini kullan

            // Her algoritmayı uygula ve sonuçları ekrana yazdır
            int dijkstraDistance = g.Dijkstra(0, distanceMatrix);
            Console.WriteLine("Toplam Mesafe (Dijkstra): " + dijkstraDistance);
            Console.WriteLine();

            int primDistance = g.Prim(distanceMatrix);
            Console.WriteLine("Toplam Mesafe (Prim): " + primDistance);
            Console.WriteLine();

            int kruskalDistance = g.Kruskal(distanceMatrix);
            Console.WriteLine("Toplam Mesafe (Kruskal): " + kruskalDistance);

            Console.ReadKey();
        }
    }
}
