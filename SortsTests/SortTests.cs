using Microsoft.EntityFrameworkCore;
using Sorts;
using Sorts.Data;
using System;
using System.Linq;
using Xunit;

namespace SortsTests
{
    public class SortTests
    {
        private readonly SortingAlgorithm sort;
        private readonly ApplicationContext context;
        public SortTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                  .UseNpgsql("Host=localhost;Port=5432;Database=SortsResultsTEST;Username=postgres;Password=1345")
                  .Options;
            context = new ApplicationContext(options);
            sort = new SelectionSort(context); //Choose sort to test
        }
        [Fact]
        public void Sort_Null_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => sort.Sort(null));
        }
        [Fact]
        public void Sort_SingleNumberArray_ReturnsSameArray()
        {
            int[] array = new int[] { 4 };
            int[] expected = new[] { 4 };

            var result = sort.Sort(array);

            Assert.Equal(expected, result.SortedArray);
        }
        [Fact]
        public void Sort_DefaultArray_ReturnsGivenArray()
        {
            int[] array = new int[] { 5, 1, 4, 2, 8 };
            int[] copyOfStartArray = new int[] { 5, 1, 4, 2, 8 };

            var result = sort.Sort(array);

            Assert.Equal(copyOfStartArray, result.StartArray);
        }
        [Theory]
        [InlineData(new int[] { 3, 1 }, new int[] { 1, 3 })]
        [InlineData(new int[] { 1, 5, 3, 2 }, new int[] { 1, 2, 3, 5 })]
        [InlineData(new int[] { 5, 1, 4, 2, 8 }, new int[] { 1, 2, 4, 5, 8 })]
        [InlineData(new int[] { -2, 1, 0, 47, 5, 6, -6 }, new int[] { -6, -2, 0, 1, 5, 6, 47 })]
        [InlineData(new int[] { -1, -234, 0, 0, 2535325, 2342, 0, -43214, 5, 55 }, new int[] { -43214, -234, -1, 0, 0, 0, 5, 55, 2342, 2535325 })]

        public void Sort_DefaultArray_ReturnsSortedArray(int[] input, int[] expected)
        {
            var result = sort.Sort(input);

            Assert.NotNull(result);
            Assert.Equal(expected, result.SortedArray);
        }
        [Fact]
        public void Sort_DefaultArray_SavesDataToDataBase()
        {
            context.Results.RemoveRange(context.Results);
            context.SaveChanges();
            int[] array = new int[] { 5, 1, 4, 2, 8 };

            sort.Sort(array);

            Assert.Equal(1, context.Results.Count());
        }
    }
}
