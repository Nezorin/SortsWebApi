using Sorts.Models;

namespace Sorts
{
    public class SortService : ISortService
    {
        private readonly SortingAlgorithm bubbleSort;
        private readonly SortingAlgorithm insertionSort;
        private readonly SortingAlgorithm selectionSort;
        private readonly SortingAlgorithm mergeSort;
        private readonly SortingAlgorithm bogoSort;

        public SortService()
        {
            bubbleSort = new BubbleSort();
            insertionSort = new InsertionSort();
            selectionSort = new SelectionSort();
            mergeSort = new MergeSort();
            bogoSort = new BogoSort();
        }
        public SortingResult Sort(int[] array, string sortName)
        {
            switch (sortName)
            {
                case "BubbleSort":
                    return bubbleSort.Sort(array);
                case "InsertionSort":
                    return insertionSort.Sort(array);
                case "SelectionSort":
                    return selectionSort.Sort(array);
                case "MergeSort":
                    return mergeSort.Sort(array);
                case "BogoSort":
                    return bogoSort.Sort(array);
                default:
                    return null;
            }
        }
    }
}
