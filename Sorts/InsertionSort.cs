using Sorts.Models;

namespace Sorts
{
    public class InsertionSort : SortingAlgorithm
    {
        public override SortingResult Sort(int[] array)
        {
            SortingResult sortingResult = CreateSortingResult(array, "InsertionSort");

            stopwatch.Start();

            for (int i = 1; i < array.Length; ++i)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }

            stopwatch.Stop();

            sortingResult.SortingTime = stopwatch.Elapsed;
            return sortingResult;
        }

    }
}
