using Sorts;
using System;
using Xunit;

namespace SortsTests
{
    public class SortTests
    {
        [Theory]
        [ClassData(typeof(SortsToTestWithTheoryData))]
        public void Sort_Null_ThrowsNullReferenceException(SortingAlgorithm sortingAlgorithm)
        {
            Assert.Throws<NullReferenceException>(() => sortingAlgorithm.Sort(null));
        }
        [Theory]
        [ClassData(typeof(SortsToTestWithTheoryData))]
        public void Sort_EmptyArray_ReturnsEmptyArray(SortingAlgorithm sortingAlgorithm)
        {
            var result = sortingAlgorithm.Sort(Array.Empty<int>());

            Assert.Equal(Array.Empty<int>(), result.SortedArray);
        }
        [Theory]
        [ClassData(typeof(SortsToTestWithTheoryData))]
        public void Sort_SingleNumberArray_ReturnsSingleNumberArray(SortingAlgorithm sortingAlgorithm)
        {
            int[] array = new int[] { 4 };
            int[] expected = new int[] { 4 };

            var result = sortingAlgorithm.Sort(array);

            Assert.Equal(expected, result.SortedArray);
        }
        [Theory]
        [ClassData(typeof(SortsToTestWithTheoryData))]
        public void Sort_DefaultArray_ReturnsGivenArrayAsStartArray(SortingAlgorithm sortingAlgorithm)
        {
            int[] array = new int[] { 5, 1, 4, 2, 8 };
            int[] expected = new int[] { 5, 1, 4, 2, 8 };

            var result = sortingAlgorithm.Sort(array);

            Assert.Equal(expected, result.StartArray);
        }
        [Theory]
        [ClassData(typeof(SortsToTestWithTheoryData))]
        public void Sort_DefaultArray_ReturnsSortedArray(SortingAlgorithm sortingAlgorithm)
        {
            int[] array = new int[] { -1, -234, 0, 0, 2535325, 2342, 0, -43214, 5, 55 };
            int[] expected = new int[] { -43214, -234, -1, 0, 0, 0, 5, 55, 2342, 2535325 };

            var result = sortingAlgorithm.Sort(array);

            Assert.Equal(expected, result.SortedArray);
        }
    }
}
