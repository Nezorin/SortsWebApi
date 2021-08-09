using Sorts.Models;

namespace Sorts
{
    public class BubbleSort : SortingAlgorithm
    {
        public override SortingResult Sort(int[] array)
        {
            SortingResult sortingResult = CreateSortingResult(array, "BubbleSort");

            stopwatch.Start();

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            stopwatch.Stop();

            sortingResult.SortingTime = stopwatch.Elapsed;
            return sortingResult;
        }
    }
}
