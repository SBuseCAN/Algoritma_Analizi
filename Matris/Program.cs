using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matris
{
    class IterativeMatrixMultiplication
    {
        public static void MultiplyMatrices(int[,] matrix1, int[,] matrix2, int[,] resultMatrix, int n)
        {
            for (int i = 0; i < n; i++)//satır sayısı için  o(n)
            {
                for (int j = 0; j < n; j++)//sütun sayısı o(n)
                {
                    resultMatrix[i, j] = 0;//her bir hüçreyi 0 dan başlatır o(n^2)
                    for (int k = 0; k < n; k++)//matris boyutu kadar çalışır o(n)
                    {
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];//O(n^3)
                    }//Üç döngünün her biri n kez çalıştığı için, iç içe üç döngü olduğunda
                     //bu ifadeyi tekrar n * n * n
                }
            }
        }
    }

    class RecursiveMatrixMultiplication
    {
        public static void MultiplyMatrices(int[,] matrix1, int[,] matrix2, int[,] resultMatrix, int row, int col, int index, int n)
        {
            if (row >= n)//O(1)
                return;//O(1)

            if (col < n)//O(1)
            {
                if (index < n)//O(1)
                {
                    resultMatrix[row, col] += matrix1[row, index] * matrix2[index, col];//O(1)
                    MultiplyMatrices(matrix1, matrix2, resultMatrix, row, col, index + 1, n);//O(n)
                }
                MultiplyMatrices(matrix1, matrix2, resultMatrix, row, col + 1, 0, n);//O(n)
            }
            MultiplyMatrices(matrix1, matrix2, resultMatrix, row + 1, 0, 0, n);//O(n)
        }
    }

    class Program
    {
        static void Main()
        {//Her bir matrisin boyutu n x n olduğu için  O(n^2)
            Console.Write("Matris boyutunu (n) giriniz: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] matrix1 = new int[n, n];
            int[,] matrix2 = new int[n, n];
            int[,] resultMatrix1 = new int[n, n];
            int[,] resultMatrix2 = new int[n, n];
            //matrisleri kullanıcıdan alır n x n olduğu için o(n^2)
            Console.WriteLine("1. matrisi giriniz:");
            MatrixInput(matrix1);

            Console.WriteLine("2. matrisi giriniz:");
            MatrixInput(matrix2);

            IterativeMatrixMultiplication.MultiplyMatrices(matrix1, matrix2, resultMatrix1, n);
            RecursiveMatrixMultiplication.MultiplyMatrices(matrix1, matrix2, resultMatrix2, 0, 0, 0, n);

            Console.WriteLine("Sonuç Matrisi = (Iterative):");//O(n^2)
            MatrixOutput(resultMatrix1);

            Console.WriteLine("Sonuç Matrisi = (Recursive):");
            MatrixOutput(resultMatrix2);
        }

        static void MatrixInput(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)//T(n)
            {
                string[] row = Console.ReadLine().Split(' ');//O(1)
                if (row.Length != matrix.GetLength(1))//O(1)
                {
                    Console.WriteLine("Hatalı giriş! Lütfen {0} elemanlı bir satır girin.", matrix.GetLength(1));//O(1)
                    i--;
                    continue;
                }
                for (int j = 0; j < matrix.GetLength(1); j++)//T(n)
                {
                    matrix[i, j] = Convert.ToInt32(row[j]);//O(1)
                }
            }
        }

        static void MatrixOutput(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)//t(n)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)//T(n)
                {
                    Console.Write(matrix[i, j] + " ");//O(1)
                }
                Console.WriteLine();//O(1)
                Console.ReadLine();
            }
        }
    }
}