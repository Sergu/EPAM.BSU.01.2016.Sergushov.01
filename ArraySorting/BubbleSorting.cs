using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorting
{
    public enum Criterion{
        ByMaxElem,
        ByMinElem,
        ByRowSum
    };
    /// <summary>
    /// Предоставляет статические методы для сортировки массивов "пузырьковым" методом по различным критериям.
    /// </summary>
    public static class BubbleSorting
    {
        interface IStradegy
        {
            int GetKey(int[] arr);
        }
        class StradegyMaxElem : IStradegy
        {
            public int GetKey(int[] arr)
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
        }
        class StradegyMinElem : IStradegy
        {
            public int GetKey(int[] arr)
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
        }
        class StradegyRowSum : IStradegy
        {
            public int GetKey(int[] arr)
            {
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }
                return sum;
            }
        }
        class Comparator : IComparer<int>
        {
            public int Compare(int numb1,int numb2)
            {
                if (numb1 == numb2)
                {
                    return 0;
                }
                else if (numb1 > numb2)
                {
                    return 1;
                }
                return -1;
            }
        }
        /// <summary>
        /// Сортирует исходный массив в порядке убывания в зависимости от передаваемого в метод критерия сравнения строк.
        /// </summary>
        /// <param name="arr">исходный массив</param>
        public static void SortDescending(int[][] arr, Criterion criterion)
        {
            IStradegy stradegy;
            switch(criterion){
                case Criterion.ByMaxElem:
                    stradegy = new StradegyMaxElem();
                    break;
                case Criterion.ByMinElem:
                    stradegy = new StradegyMinElem();
                    break;
                case Criterion.ByRowSum:
                    stradegy = new StradegyRowSum();
                    break;
                default:
                    stradegy = new StradegyRowSum();
                    break;
            };
            SortDesc(arr, new Comparator(), stradegy);
        }
        /// <summary>
        /// Сортирует исходный массив в порядке возрастания в зависимости от передаваемого в метод критерия сравнения строк.
        /// </summary>
        /// <param name="arr">исходный массив</param>

        public static void SortAscending(int[][] arr, Criterion criterion)
        {
            IStradegy stradegy;
            switch (criterion)
            {
                case Criterion.ByMaxElem:
                    stradegy = new StradegyMaxElem();
                    break;
                case Criterion.ByMinElem:
                    stradegy = new StradegyMinElem();
                    break;
                case Criterion.ByRowSum:
                    stradegy = new StradegyRowSum();
                    break;
                default:
                    stradegy = new StradegyRowSum();
                    break;
            };
            SortAsc(arr, new Comparator(), stradegy);
        }
        /// <summary>
        /// Сортирует исходный массив в порядке возрастания максимальных элементов строк матрицы.
        /// </summary>
        /// <param name="arr">исходный массив</param>
        
        private static void SortAsc(int[][] arr,IComparer<int> comparator,IStradegy stradegy)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    int firstKey = stradegy.GetKey(arr[j]);
                    int secKey = stradegy.GetKey(arr[j + 1]);
                    if (comparator.Compare(firstKey, secKey) == -1)
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }

        private static void SortDesc(int[][] arr,IComparer<int> comparator,IStradegy stradegy)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    int firstKey = stradegy.GetKey(arr[j]);
                    int secKey = stradegy.GetKey(arr[j + 1]);
                    if(comparator.Compare(firstKey,secKey) == 1)
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
