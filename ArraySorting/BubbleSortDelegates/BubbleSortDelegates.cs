using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorting
{
    public static class KeyCalculator
    {
        public static int GetMaxElem(int[] arr)
        {
            IStradegy stradegy = new MaxElemCalculator();
            return stradegy.GetKey(arr);
        }
        public static int GetMinElem(int[] arr)
        {
            IStradegy stradegy = new MinElemCalculator();
            return stradegy.GetKey(arr);
        }
        public static int GetRowSum(int[] arr)
        {
            IStradegy stradegy = new RowSumCalculator();
            return stradegy.GetKey(arr);
        }
    }
    public interface IStradegy
    {
        int GetKey(int[] arr);
    }
    public class MaxElemCalculator : IStradegy
    {
        public int GetKey(int[] arr)
        {
            if (ReferenceEquals(arr, null))
                return int.MinValue;
            if (arr.Length == 0)
                return int.MinValue;
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
    }
    public class MinElemCalculator : IStradegy
    {
        public int GetKey(int[] arr)
        {
            if (ReferenceEquals(arr, null))
                return int.MaxValue;
            if (arr.Length == 0)
                return int.MaxValue;
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
    }
    public class RowSumCalculator : IStradegy
    {
        public int GetKey(int[] arr)
        {
            if (ReferenceEquals(arr, null))
                return int.MinValue;
            if (arr.Length == 0)
                return int.MinValue;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
    }
    public class Comparator : IComparer<int>
    {
        public int Compare(int numb1, int numb2)
        {
            return numb1 - numb2;
        }
    }
    /// <summary>
    /// Предоставляет статические методы для сортировки массивов "пузырьковым" методом по различным критериям.
    /// </summary>
    public static class BubbleSortDelegates
    {
        public delegate int GetKeyDelegate(int[] arr);
        /// <summary>
        /// Сортирует исходный массив в порядке возрастания в зависимости от передаваемого в метод критерия сравнения строк.
        /// </summary>
        /// <param name="arr">исходный массив</param>

        public static void BubbleSort(int[][] arr, GetKeyDelegate del)
        {
            if (ReferenceEquals(null, arr))
                throw new NullReferenceException();
            if (ReferenceEquals(null, del))
                throw new NullReferenceException();
            Sort(arr, new Comparator(), del);
        }
        /// <summary>
        /// Сортирует исходный массив в порядке возрастания максимальных элементов строк матрицы.
        /// </summary>
        /// <param name="arr">исходный массив</param>
        
        private static void Sort(int[][] arr,IComparer<int> comparator,GetKeyDelegate del)
        {
            if (ReferenceEquals(null, arr))
                throw new NullReferenceException();
            if (ReferenceEquals(null, comparator))
                throw new NullReferenceException();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    int firstKey = del(arr[j]);
                    int secKey = del(arr[j + 1]);
                    if (comparator.Compare(firstKey, secKey) > 1)
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        private static void Swap(ref int[] firstRow,ref int[] secondRow)
        {
            int[] temp = secondRow;
            secondRow = firstRow;
            firstRow = temp;
        }
    }
}
