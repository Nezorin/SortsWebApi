using Sorts.Models;

namespace Sorts
{
    public class SelectionSort : SortingAlgorithm
    {
        public override SortingResult Sort(int[] array)
        {
            SortingResult sortingResult = CreateSortingResult(array, "SelectionSort");

            stopwatch.Start();

            for (int i = 0; i < array.Length - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j] < array[min_idx])
                        min_idx = j;
                if (min_idx != i)
                {
                    Swap(ref array[min_idx], ref array[i]);
                }
            }

            stopwatch.Stop();

            sortingResult.SortingTime = stopwatch.Elapsed;

            return sortingResult;
        }
    }
}
