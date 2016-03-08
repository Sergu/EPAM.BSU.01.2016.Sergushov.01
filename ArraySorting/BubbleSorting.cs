using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorting
{
    /// <summary>
    /// Предоставляет статические методы для сортировки массивов "пузырьковым" методом по различным критериям.
    /// </summary>
    public static class BubbleSorting
    {
        /// <summary>
        /// Сортирует исходный массив в порядке убывания минимальных элементов строк матрицы.
        /// </summary>
        /// <param name="arr">исходный массив</param>
        public static void RowSortDescendingByMinElem(int[][] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (GetMinElement(arr[j]) < GetMinElement(arr[j + 1]))
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
        }
        /// <summary>
        /// Сортирует исходный массив в порядке возрастания минимальных элементов строк матрицы.
        /// </summary>
        /// <param name="arr">исходный массив</param>
        public static void RowSortAscendingByMinElem(int[][] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (GetMinElement(arr[j]) > GetMinElement(arr[j + 1]))
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
        }
        /// <summary>
        /// Сортирует исходный массив в порядке возрастания максимальных элементов строк матрицы.
        /// </summary>
        /// <param name="arr">исходный массив</param>
        public static void RowSortAscendingByMaxElem(int[][] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (GetMaxElement(arr[j]) > GetMaxElement(arr[j + 1]))
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
        }
        /// <summary>
        /// Cортирует исходный массив в порядке убывания максимальных элементов строк матрицы.
        /// </summary>
        /// <param name="arr">исходный массив</param>
        public static void RowSortDescendingByMaxElem(int[][] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (GetMaxElement(arr[j]) < GetMaxElement(arr[j + 1]))
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
        }
        /// <summary>
        /// Сортирует исходный массив в порядке возрастания сумм элементов строк матрицы;
        /// </summary>
        /// <param name="arr">исходный массив</param>
        public static void RowSortAscendingBySum(int[][] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (GetRowSum(arr[j]) > GetRowSum(arr[j + 1]))
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
        }
        /// <summary>
        /// Сортирует исходный массив в порядке убывания сумм элементов строк матрицы;
        /// </summary>
        /// <param name="arr">исходный массив</param>
        public static void RowSortDescendingBySum(int[][] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (GetRowSum(arr[j]) < GetRowSum(arr[j + 1]))
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
        }
        private static int GetMaxElement(int[] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        private static int GetMinElement(int[] arr)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        private static int GetRowSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        private static void Swap(int[][] arr, int firstRow, int secondRow)
        {
            int[] temp = arr[secondRow];
            arr[secondRow] = arr[firstRow];
            arr[firstRow] = temp;
        }
    }
}
