using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArraySorting;

namespace ArraySortingTests
{
    [TestClass]
    public class BubbleSoertingTests
    {
        [TestMethod]
        [ExpectedException (typeof(NullReferenceException))]
        public void SortAscending_nullArray_throwsException()
        {
            int[][] arr = null;
            BubbleSorting.SortAscending(arr, Criterion.ByMinElem);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SortDescending_nullArray_throwsException()
        {
            int[][] arr = null;
            BubbleSorting.SortDescending(arr, Criterion.ByMinElem);
        }
        [TestMethod]
        public void SortAscending_NotNullArray_CriterialByMaxElem_equalsResultArray()
        {
            int[][] arr = new int[][]{
                new int[] {4,-1,102,235,123 },
                new int[] {-12,-564},
                new int[] {}
            };
            int[][] resultArray = new int[][]{
                new int[] {},
                new int[] {-12,-564},
                new int[] {4,-1,102,235,123 }
            };
            BubbleSorting.SortAscending(arr, Criterion.ByMaxElem);
            Assert.AreEqual(arr, resultArray);
        }
        [TestMethod]
        public void SortDecending_NotNullArray_CriterialByMinElem_equalsResultArray()
        {
            int[][] arr = new int[][]{
                new int[] {4,-1,102,235,123 },
                new int[] {-12,-564,34},
                new int[] {0,0},
                new int[] {}
            };
            int[][] resultArray = new int[][]{
                new int[] {},
                new int[] {-12,-564,34},
                new int[] {4,-1,102,235,123 },
                new int[] {0,0}
            };
            BubbleSorting.SortAscending(arr, Criterion.ByMinElem);
            Assert.AreEqual(arr, resultArray);
        }
        [TestMethod]
        public void SortAscending_NotNullArray_CriterialByRowSum_equalsResultArray()
        {
            int[][] arr = new int[][]{
                new int[] {4,-1,10,23,123 },
                new int[] {-12,-564},
                new int[] {},
                new int[] {1,2,3}
            };
            int[][] resultArray = new int[][]{
                new int[] {},
                new int[] {-12,-564},
                new int[] {4,-1,10,23,123 },
                new int[] {1,2,3}
            };
            BubbleSorting.SortAscending(arr, Criterion.ByRowSum);
            Assert.AreEqual(arr, resultArray);
        }
    }
}
