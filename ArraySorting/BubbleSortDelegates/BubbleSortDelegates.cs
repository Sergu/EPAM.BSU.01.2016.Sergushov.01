using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorting
{
    public static class ArrayComparer
    {
        public static int CompareByMaxElem(int[] arr1,int[] arr2)
        {
            IComparer<int[]> stradegy = new MaxElemComparer();
            return stradegy.Compare(arr1,arr2);
        }
        public static int CompareByMinElem(int[] arr1,int[] arr2)
        {
            IComparer<int[]> stradegy = new MinElemComparer();
            return stradegy.Compare(arr1,arr2);
        }
        public static int CompareByRowSum(int[] arr1,int[] arr2)
        {
            IComparer<int[]> stradegy = new RowSumComparer();
            return stradegy.Compare(arr1,arr2);
        }
    }
    public class MaxElemComparer : IComparer<int[]>
    {
        private int GetKey(int[] arr)
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
        public int Compare(int[] x, int[] y)
        {
            if (GetKey(x) == GetKey(y))
                return 0;
            else
            {
                if (GetKey(x) > GetKey(y))
                    return 1;
                else
                    return 0;
            }
        }
    }
    public class MinElemComparer : IComparer<int[]>
    {
        private int GetKey(int[] arr)
        {
            if (ReferenceEquals(arr, null))
                return int.MinValue;
            if (arr.Length == 0)
                return int.MinValue;
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
        public int Compare(int[] x, int[] y)
        {
            if (GetKey(x) == GetKey(y))
                return 0;
            else
            {
                if (GetKey(x) > GetKey(y))
                    return 1;
                else
                    return 0;
            }
        }
    }
    public class RowSumComparer : IComparer<int[]>
    {
        private int GetKey(int[] arr)
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
        public int Compare(int[] x, int[] y)
        {
            if (GetKey(x) == GetKey(y))
                return 0;
            else
            {
                if (GetKey(x) > GetKey(y))
                    return 1;
                else
                    return 0;
            }
        }
    }
    /// <summary>
    /// Предоставляет статические методы для сортировки массивов "пузырьковым" методом по различным критериям.
    /// </summary>
    public static class BubbleSortDelegates
    {
        public delegate int CompareDelegate(int[] arr1,int[] arr2);
        /// <summary>
        /// Сортирует исходный массив в порядке возрастания в зависимости от передаваемого в метод критерия сравнения строк.
        /// </summary>
        /// <param name="arr">исходный массив</param>

        public static void BubbleSort(int[][] arr, CompareDelegate del)
        {
            if (ReferenceEquals(null, arr))
                throw new NullReferenceException();
            if (ReferenceEquals(null, del))
                throw new NullReferenceException();
            Sort(arr, del);
        }
        
        private static void Sort(int[][] arr,CompareDelegate del)
        {
            if (ReferenceEquals(null, arr))
                throw new NullReferenceException();
            if (ReferenceEquals(null, del))
                throw new NullReferenceException();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (del(arr[j],arr[j+1]) > 0)
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
