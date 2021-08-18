using Sorts;
using Xunit;

namespace SortsTests
{
    class SortsToTestWithTheoryData : TheoryData<SortingAlgorithm>
    {
        public SortsToTestWithTheoryData()
        {
            Add(new BubbleSort());
            Add(new SelectionSort());
            Add(new MergeSort());
            Add(new InsertionSort());
            Add(new BogoSort());
        }
    }
}
