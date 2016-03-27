using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorting
{
    public static class KeysMethods
    {
        public static int GetMaxElem(int[] arr)
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
        public static int GetMinElem(int[] arr)
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
        public static int GetRowSum(int[] arr)
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
    public class StradegyMaxElem : IStradegy
    {
        public int GetKey(int[] arr)
        {
            BubbleSortInterfaces.GetKeyDelegate del = new BubbleSortInterfaces.GetKeyDelegate(KeysMethods.GetMaxElem);
            return del(arr);
        }
    }
    public class StradegyMinElem : IStradegy
    {
        public int GetKey(int[] arr)
        {
            BubbleSortInterfaces.GetKeyDelegate del = new BubbleSortInterfaces.GetKeyDelegate(KeysMethods.GetMinElem);
            return del(arr);
        }
    }
    public class StradegyRowSum : IStradegy
    {
        public int GetKey(int[] arr)
        {
            BubbleSortInterfaces.GetKeyDelegate del = new BubbleSortInterfaces.GetKeyDelegate(KeysMethods.GetRowSum);
            return del(arr);
        }
    }
    public static class BubbleSortInterfaces
    {
        public delegate int GetKeyDelegate(int[] arr);
        public static void BubbleSort(int[][] arr, IStradegy stradegy)
        {
            if (ReferenceEquals(null, arr))
                throw new NullReferenceException();
            if (ReferenceEquals(null, stradegy))
                throw new NullReferenceException();
            Sort(arr, new Comparator(), stradegy);
        }
        public static void Sort(int[][] arr, IComparer<int> comparator, IStradegy stradegy)
        {
            if (ReferenceEquals(null, arr))
                throw new NullReferenceException();
            if (ReferenceEquals(null, comparator))
                throw new NullReferenceException();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    int firstKey = stradegy.GetKey(arr[j]);
                    int secKey = stradegy.GetKey(arr[j + 1]);
                    if (comparator.Compare(firstKey, secKey) > 1)
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        private static void Swap(ref int[] firstRow, ref int[] secondRow)
        {
            int[] temp = secondRow;
            secondRow = firstRow;
            firstRow = temp;
        }
    }
}
