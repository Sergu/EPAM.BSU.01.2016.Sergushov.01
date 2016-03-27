using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorting
{
    public static class CompareArrays
    {
        public static int CompareByMaxElem(int[] arr1, int[] arr2)
        {
            if (GetMaxElem(arr1) == GetMaxElem(arr2))
                return 0;
            else
            {
                if (GetMaxElem(arr1) > GetMaxElem(arr2))
                    return 1;
                else
                    return 0;
            }
        }
        public static int CompareByMinElem(int[] arr1,int[] arr2)
        {
            if (GetMinElem(arr1) == GetMinElem(arr2))
                return 0;
            else
            {
                if (GetMinElem(arr1) > GetMinElem(arr2))
                    return 1;
                else
                    return 0;
            }
        }
        public static int CompareByRowSum(int[] arr1,int[] arr2)
        {
            if (GetRowSum(arr1) == GetRowSum(arr2))
                return 0;
            else
            {
                if (GetRowSum(arr1) > GetRowSum(arr2))
                    return 1;
                else
                    return 0;
            }
        }
        private static int GetMaxElem(int[] arr)
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
        private static int GetMinElem(int[] arr)
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
        private static int GetRowSum(int[] arr)
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
    public class ComparerMaxElem : IComparer<int[]>
    {
        public int Compare(int[] x,int[] y)
        {
            BubbleSortInterfaces.GetKeyDelegate del = new BubbleSortInterfaces.GetKeyDelegate(CompareArrays.CompareByMaxElem);
            return del(x,y);
        }
    }
    public class ComparerMinElem : IComparer<int[]>
    {
        public int Compare(int[] x,int[] y)
        {
            BubbleSortInterfaces.GetKeyDelegate del = new BubbleSortInterfaces.GetKeyDelegate(CompareArrays.CompareByMinElem);
            return del(x,y);
        }
    }
    public class ComparerRowSum : IComparer<int[]>
    {
        public int Compare(int[] x,int[] y)
        {
            BubbleSortInterfaces.GetKeyDelegate del = new BubbleSortInterfaces.GetKeyDelegate(CompareArrays.CompareByRowSum);
            return del(x,y);
        }
    }
    public static class BubbleSortInterfaces
    {
        public delegate int GetKeyDelegate(int[] arr1,int[] arr2);
        public static void BubbleSort(int[][] arr, IComparer<int[]> stradegy)
        {
            if (ReferenceEquals(null, arr))
                throw new NullReferenceException();
            if (ReferenceEquals(null, stradegy))
                throw new NullReferenceException();
            Sort(arr, stradegy);
        }
        private static void Sort(int[][] arr, IComparer<int[]> stradegy)
        {
            if (ReferenceEquals(null, arr))
                throw new NullReferenceException();
            if (ReferenceEquals(null, stradegy))
                throw new NullReferenceException();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (stradegy.Compare(arr[j],arr[j+1]) > 0)
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
